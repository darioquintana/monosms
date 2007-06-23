using System.Collections.Generic;

namespace Mono.Sms.Core
{
    public class SmtpServers : Dictionary<string, string>
    {
        public SmtpServers()
        {
            this.Add("Gigared", "mail.gigared.com");
            this.Add("Arnet","smtp.arnet.com.ar");
            this.Add("Nodo Alem","mail.nodoalem.com.ar");
            this.Add("Ciudad","smtp.ciudad.com.ar");
            this.Add("Impsat", "smtp.impsat1.com.ar");
            this.Add("Fibertel","smtp.fibertel.com.ar");
        }
    }
}