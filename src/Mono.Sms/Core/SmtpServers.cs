using System.Collections.Generic;

namespace Mono.Sms.Core
{
    public class SmtpServers : Dictionary<string, string>
    {
        public SmtpServers()
        {
            this.Add("Gigared", "mail.gigared.com");
            this.Add("Arnet","smtp.arnet.com.ar");
            this.Add("NodoAlem","mail.nodoalem.com.ar");
        }
    }
}