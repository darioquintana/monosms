namespace Mono.Sms.Core.Provider
{
    public class CtiProvider : BaseProvider
    {
         public CtiProvider(string message, CelNumber number)
            : base(message, number)
        {
           
            this.Message = message;
            this.CelNumber = number;
        }

        public CtiProvider()
        {
            
        }

      
    }
}