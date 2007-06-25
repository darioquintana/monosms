using System.Web;

namespace Mono.Sms.Core.Provider
{
    public class PersonalProvider : BaseProvider
    {
        public PersonalProvider(string message, CelNumber number)
            : base(message, number)
        {
            //Example of configuration. This parameters are inyected by Windsor.
            //this.Name = "Personal";
            //this.Domain = "@personal-net.com.ar";
            //this.UseSmtp = false;
            //this.HostName = "200.43.139.25";
            //this.Port = 80;
            //this.numberOfCharacters = 138;
            //this.Description = "some description about this provider

            this.Message = message;
            this.CelNumber = number;
        }

        public override string DataPost
        {
            get
            {
                //MessageBox.Show(string.Format("Mensaje a mandar antes de ser formateado: {0}", Message));

                //string messageUrlFormated = HttpUtility.UrlEncode(this.Message);
                string messageUrlFormated = Message
                    
                    //Compilar esto en Mono/Linux, no funciona.
                    //.Replace('á', 'a')
                    //.Replace('é', 'e')
                    //.Replace('í', 'i')
                    //.Replace('ó', 'o')
                    //.Replace('ú', 'u')
                    //.Replace('ñ', 'n');
                                       
                    //.Replace(char.Parse("á"), char.Parse("a"))
                    //.Replace(char.Parse("é"), char.Parse("e"))
                    //.Replace(char.Parse("í"), char.Parse("i"))
                    //.Replace(char.Parse("ó"), char.Parse("o"))
                    //.Replace(char.Parse("ú"), char.Parse("u"))
                    //.Replace(char.Parse("ñ"), char.Parse("n"));
                    .Replace(char.Parse("\u00E1"), char.Parse("a"))
                    .Replace(char.Parse("\u00E9"), char.Parse("e"))
                    .Replace(char.Parse("\u00ED"), char.Parse("i"))
                    .Replace(char.Parse("\u00F3"), char.Parse("o"))
                    .Replace(char.Parse("\u00FA"), char.Parse("u"))
                    .Replace(char.Parse("\u00F1"), char.Parse("n"));

                messageUrlFormated = HttpUtility.UrlEncode(messageUrlFormated);

                messageUrlFormated = messageUrlFormated.Replace("\r\n", "%0D%0A");

                //MessageBox.Show(string.Format("Mensaje a mandar despues de ser formateado: {0}", messageUrlFormated));

                string innerData =
                    string.Format("btn_send=SEND&form=ht4&msgtext={0}&sig={1}&size=10&Snb={2}&subname={2}",
                                  messageUrlFormated, this.Sign, this.CelNumber);

                return string.Format(
                    @"POST /cgi-bin/pagepage HTTP/1.1
Accept: image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/xaml+xml, application/vnd.ms-xpsdocument, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/ag-plugin, */*
Accept-Language: es-us
Content-Type: application/x-www-form-urlencoded
UA-CPU: x86
Accept-Encoding: gzip, deflate
User-Agent: Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.30; FDM)
Host: 200.43.139.25
Content-Length: {0}
Connection: Keep-Alive
Cache-Control: no-cache

{1}",
                    innerData.Length, innerData);
            }
        }

        public PersonalProvider()
        {
        }
    }
}