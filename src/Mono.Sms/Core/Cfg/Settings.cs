namespace Mono.Sms.Core.Cfg
{
    public class Settings
    {
        private string userEmail;
        private string userName;
        private string smtpServer;

        public Settings()
        {
            UserEmail = CfgHelper.Instance.GetSection.Settings["user.email"].Value;

            UserName = CfgHelper.Instance.GetSection.Settings["user.email"].Value;

            SmtpServer = CfgHelper.Instance.GetSection.Settings["smtp.server"].Value;
        }


        public void SaveState()
        {
             

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