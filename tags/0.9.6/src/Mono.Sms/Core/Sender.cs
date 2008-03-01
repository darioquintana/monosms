using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Web;
using Mono.Sms.Core.Cfg;
using Mono.Sms.Core.Provider;

namespace Mono.Sms.Core
{
    public class Sender
    {
        public Result Send(IProvider provider)
        {
            if (provider.UseSmtp)
            {
                return SendMail(provider);
            }
            else
            {
                return SendPost(provider);
            }
        }

        private Result SendMail(IProvider provider)
        {
            IMailSender mailsender = IoC.Instance.Resolve<IMailSender>();
            mailsender.SmtpServer = Settings.Instance.SmtpServer;
            mailsender.From = Settings.Instance.UserEmail;
            mailsender.To = string.Format("{0}{1}{2}", provider.CelNumber.CodeArea, provider.CelNumber.Number, provider.Domain);
            mailsender.Message = provider.Message;
            mailsender.Subject = "mono.sms";

            return mailsender.Send();
        }

        private Result SendPost(IProvider provider)
        {
            try
            {
                //esto necesita refactoring urgente !!!

                string hostName = provider.HostName;

                string primerRequest =
                    @"GET /Mensajes/sms_web.php HTTP/1.1
Host: sms.personal.com.ar
Connection: Keep-Alive, TE
Accept-Encoding: gzip
Accept: text/xml,application/xml,application/xhtml+xml,text/html;q=0.9,text/plain;q=0.8,image/png,*/*;q=0.5
Accept-Language: es-es,es;q=0.8,en-us;q=0.5,en;q=0.3
Accept-Charset: ISO-8859-1,utf-8;q=0.7,*;q=0.7
User-Agent:  Opera/9.21 (Windows NT 5.1; U; es-es)
Referer: http://web-sniffer.net/

";
                string primerResponse = SendRequest(primerRequest, hostName);

                string cookieToSet = GetHttpProperty(primerResponse, "Set-Cookie");

                string PHPSESSID = GetPHPSESSID(cookieToSet);

                string segundoRequest =
                    string.Format(
                        @"GET /Mensajes/validar.php HTTP/1.1
User-Agent: Opera/9.21 (Windows NT 5.1; U; es-es)
Host: sms.personal.com.ar
Accept: text/html, application/xml;q=0.9, application/xhtml+xml, image/png, image/jpeg, image/gif, image/x-xbitmap, */*;q=0.1
Accept-Language: es-es,es;q=0.9,en;q=0.8
Accept-Charset: iso-8859-1, utf-8, utf-16, *;q=0.1
Accept-Encoding: deflate, gzip, x-gzip, identity, *;q=0
Referer: http://sms.personal.com.ar/Mensajes/sms_web.php
Cookie: PHPSESSID={0}
Cookie2: $Version=1
Connection: Keep-Alive, TE
TE: deflate, gzip, chunked, identity, trailers

",
                        PHPSESSID);

                string segundoResponse = SendRequest(segundoRequest, hostName);

                string ImageURL = GetImageName(segundoResponse);

                CodigoValidacion frm = new CodigoValidacion();
                frm.PictureBox.ImageLocation = string.Format("http://sms.personal.com.ar/Mensajes/{0}", ImageURL);
                //frm.PictureBox.Load(string.Format("http://sms.personal.com.ar/Mensajes/{0}", ImageURL));
                frm.ShowDialog();
                string codigoValidacion = frm.CodigoDeValidacion;

                string messageUrlFormated = provider.Message
                    .Replace(char.Parse("\u00E1"), char.Parse("a"))
                    .Replace(char.Parse("\u00E9"), char.Parse("e"))
                    .Replace(char.Parse("\u00ED"), char.Parse("i"))
                    .Replace(char.Parse("\u00F3"), char.Parse("o"))
                    .Replace(char.Parse("\u00FA"), char.Parse("u"))
                    .Replace(char.Parse("\u00F1"), char.Parse("n"));

                messageUrlFormated = PrepararMensaje(messageUrlFormated);

                messageUrlFormated = HttpUtility.UrlEncode(messageUrlFormated);

                messageUrlFormated = messageUrlFormated.Replace("\r\n", "%0D%0A");

              

                string innerData =
                    string.Format(
                        "pantalla=&DE_MESG_TXT={0}&msgtext={1}&Snb={2}&Filename={3}&FormValidar=validar&codigo={4}&Image30.x=0&Image30.y=0",
                        "", messageUrlFormated, provider.CelNumber, HttpUtility.UrlEncode(ImageURL), codigoValidacion);
                //from
                //mensaje
                //numero
                //filename
                //codigo

                string tercerRequest =
                    string.Format(
                        @"POST /Mensajes/validar.php HTTP/1.1
User-Agent: Opera/9.21 (Windows NT 5.1; U; es-es)
Host: sms.personal.com.ar
Accept: text/html, application/xml;q=0.9, application/xhtml+xml, image/png, image/jpeg, image/gif, image/x-xbitmap, */*;q=0.1
Accept-Language: es-es,es;q=0.9,en;q=0.8
Accept-Charset: iso-8859-1, utf-8, utf-16, *;q=0.1
Accept-Encoding: deflate, gzip, x-gzip, identity, *;q=0
Referer: http://sms.personal.com.ar/Mensajes/validar.php
Cookie: PHPSESSID={0}
Cookie2: $Version=1
Connection: Keep-Alive, TE
TE: deflate, gzip, chunked, identity, trailers
Content-Length: {1}
Content-Type: application/x-www-form-urlencoded

{2}",
                        PHPSESSID, innerData.Length, innerData);

                string tercerResponse = this.SendRequest(tercerRequest, hostName);

                string imagePathMustBeEmpty = GetImageName(tercerResponse);

                if (imagePathMustBeEmpty == string.Empty)
                {
                    return new Result("El Mensaje fué enviado correctamente");
                }
                else
                {
                    //error el codigo de validación fué incorrecto.
                    return new Result("Debe intentar nuevamente", "Ha ingresado mal el código de validación");
                }
            }
            catch(Exception ex)
            {
                return new Result("No se pudo enviar con este provedor, intente con el Proveedor 'Personal - por e-mail'", ex.Message);
            }
        }

        private string PrepararMensaje(string messageUrlFormated) 
        {
            string trailer = " - Mono.Sms";

            messageUrlFormated = string.Concat(messageUrlFormated, trailer);

            return messageUrlFormated.PadRight(160, ' ');
        }

        private string SendRequest(string request, string hostname)
        {
            try
            {
                TcpClient client = new TcpClient(hostname, 80);

                UTF8Encoding enc = new UTF8Encoding();

                byte[] msg = enc.GetBytes(request);

                client.GetStream().Write(msg, 0, msg.Length);

                client.GetStream().Flush();

                byte[] readBuffer = new byte[100000];

                client.GetStream().Read(readBuffer, 0, readBuffer.Length);

                //Checkear recepcion de http 200 ok
                return enc.GetString(readBuffer, 0, readBuffer.Length);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private string GetHttpProperty(string response, string property)
        {
            using (StringReader sr = new StringReader(response))
            {
                string linea;
                do
                {
                    linea = sr.ReadLine();

                    string[] array = linea.Split(':');

                    if (array[0].Trim() == property.Trim())
                    {
                        return array[1].Trim();
                    }
                } while (linea != string.Empty);
            }
            return null;
        }

        private string GetPHPSESSID(string cadena)
        {
            return cadena.Substring("PHPSESSID=".Length, 26);
        }


        private string GetImageName(string response)
        {
            string matchString = "Filename";
            //   tmp/7217t7g82l7e02o7.png <-- tiene 24 caracteres.

            using (StringReader sr = new StringReader(response))
            {
                string linea;
                do
                {
                    linea = sr.ReadLine();

                    if (linea.Contains(matchString))
                    {
                        string[] array = linea.Split('"');

                        return array[5];
                    }
                } while (linea != string.Empty || !linea.Contains("</html>"));
            }
            return null;
        }
    }
}