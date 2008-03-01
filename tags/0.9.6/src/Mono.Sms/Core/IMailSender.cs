namespace Mono.Sms.Core
{
    internal interface IMailSender
    {
        string From { get; set; }
        string Message { get; set; }
        Result Send();
        string SmtpServer { get; set; }
        string Subject { get; set; }
        string To { get; set; }
    }
}