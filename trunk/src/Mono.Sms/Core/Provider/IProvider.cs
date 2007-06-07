namespace Mono.Sms.Core.Provider
{
    public interface IProvider
    {
        string Name { get; set; }
        string Domain { get; set; }
        bool UseSmtp { get; set; }
        string HostName { get; set; }
        string DataPost { get; }
        string Sign { get; }
        string Message { get; set; }
        CelNumber CelNumber { get; set; }
        int NumberOfCharacters { set; get; }
        string Description { get; set; }
    }
}