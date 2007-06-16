using System;
using System.Net.Sockets;
using System.Text;
using Mono.Sms.Core.Cfg;
using Mono.Sms.Core.Provider;

namespace Mono.Sms.Core
{
    public class Sender
    {
        public Sender()
        {
        }

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
            mailsender.To =
                string.Format("{0}{1}{2}", provider.CelNumber.CodeArea, provider.CelNumber.Number, provider.Domain);
            mailsender.Message = provider.Message;
            mailsender.Subject = "mono.sms";

            return mailsender.Send();
        }

        private Result SendPost(IProvider provider)
        {
            try
            {
                TcpClient client = new TcpClient(provider.HostName, 80);

                UTF8Encoding enc = new UTF8Encoding();

                byte[] msg = enc.GetBytes(provider.DataPost);

                client.GetStream().Write(msg, 0, msg.Length);

                client.GetStream().Flush();

                byte[] readBuffer = new byte[300];

                client.GetStream().Read(readBuffer, 0, 300);

                string leido = enc.GetString(readBuffer, 0, readBuffer.Length);

                return new Result("Se ha enviado correctamente el mensaje");
            }

            catch (Exception ex)
            {
                return new Result("No se pudo enviar el mensaje", ex.Message);
            }
        }
    }
}