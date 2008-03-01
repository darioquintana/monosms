namespace Mono.Sms.Core.Cfg
{
    public class Settings
    {
        private static Settings settings;

        public static Settings Instance
        {
            get
            {
                if (settings == null)
                {
                    settings = new Settings();
                }

                return settings;
            }
        }


        private string userEmail;
        private string userName;
        private string smtpServer;

        private Settings()
        {
            this.UserEmail = CfgHelper.Instance.GetSection.Settings["user.email"].Value;

            this.UserName = CfgHelper.Instance.GetSection.Settings["user.name"].Value;

            this.SmtpServer = CfgHelper.Instance.GetSection.Settings["smtp.server"].Value;
        }

        public void SaveState()
        {
            CfgHelper.WriteConfiguration(this.UserEmail, this.UserName, this.SmtpServer);
        }

        public string UserEmail
        {
            get { return userEmail; }
            set { userEmail = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string SmtpServer
        {
            get { return smtpServer; }
            set { smtpServer = value; }
        }
    }
}