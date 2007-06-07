namespace Mono.Sms.Core.Provider
{
    public class BaseProvider : IProvider
    {
        public BaseProvider()
        {
        }

        public BaseProvider(string message, CelNumber celNumber)
        {
            this.message = message;
            this.celNumber = celNumber;
        }

        protected string name = string.Empty;
        protected string domain = string.Empty;
        protected bool useSmtp;
        //protected string dataPost;
        protected string hostName;
        protected int port;
        protected string sign = "monosms.-";
        protected string message;
        protected CelNumber celNumber;
        protected int numberOfCharacters = 0;
        private string description;

        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Domain
        {
            get { return this.domain; }
            set { this.domain = value; }
        }


        public bool UseSmtp
        {
            get { return useSmtp; }
            set { useSmtp = value; }
        }

        public string HostName
        {
            get { return hostName; }
            set { hostName = value; }
        }

        public virtual string DataPost
        {
            get { return string.Empty; }
        }

        public string Sign
        {
            get { return sign; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public CelNumber CelNumber
        {
            get { return celNumber; }
            set { celNumber = value; }
        }

        public int NumberOfCharacters
        {
            get { return numberOfCharacters; }
            set { numberOfCharacters = value; }
        }


        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public override string ToString()
        {
            return string.Concat("Provider: ", this.Name);
        }
    }
}