using System;
using System.Net.Mail;

namespace Mono.Sms.Core
{
    public class MailSender : IMailSender
    {
        private string message;
        private string subject;
        private string smtpServer;
        private string to;
        private string from;

        public string Message
        {
            get { return this.message; }
            set { this.message = value; }
        }


        public string Subject
        {
            get { return this.subject; }
            set { this.subject = value; }
        }


        public string SmtpServer
        {
            get { return this.smtpServer; }
            set { this.smtpServer = value; }
        }

        public string To
        {
            get { return this.to; }
            set { this.to = value; }
        }

        public string From
        {
            get { return this.from; }
            set { this.from = value; }
        }

        public Result Send()
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(this.From);

            mail.Body = this.message;

            mail.To.Add(this.To);

            mail.Subject = this.subject;

            mail.IsBodyHtml = false;

            SmtpClient smtpCli = new SmtpClient(smtpServer);

            try
            {
                smtpCli.Send(mail);

                return new Result("El mensaje se envió correctamente");
            }
            catch (Exception ex)
            {
                return new Result("No se pudo enviar el mensaje", ex.Message);
            }
        }
    }
}