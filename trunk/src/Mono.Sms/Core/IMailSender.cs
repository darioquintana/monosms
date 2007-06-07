using System;
namespace Mono.Sms.Core
{
    interface IMailSender
    {
        string From { get; set; }
        string Message { get; set; }
        Result Send();
        string SmtpServer { get; set; }
        string Subject { get; set; }
        string To { get; set; }
    }
}
