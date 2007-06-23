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
                //string messageUrlFormated = HttpUtility.UrlEncode(this.Message);
                string messageUrlFormated = Message
                    .Replace('�', 'a')
                    .Replace('�', 'e')
                    .Replace('�', 'i')
                    .Replace('�', 'o')
                    .Replace('�', 'u')
                    .Replace('�', 'n');
                    
                    //.Replace("%", "%25")
                    //.Replace("&", "	%26")
                    //.Replace("/", "%2F");
                
                //messageUrlFormated = HttpUtility.UrlPathEncode(messageUrlFormated);
                messageUrlFormated = HttpUtility.UrlEncode(messageUrlFormated);
                
                messageUrlFormated = messageUrlFormated.Replace("\r\n", "%0D%0A");
                

            string innerData = string.Format("btn_send=SEND&form=ht4&msgtext={0}&sig={1}&size=10&Snb={2}&subname={2}", messageUrlFormated, this.Sign,this.CelNumber);

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

{1}",innerData.Length,innerData); 
           
                
            }
        }

        public PersonalProvider()
        {
            
        }

       
    }
}