using System;
using System.Configuration;

namespace Mono.Sms.Core.Cfg
{
    public sealed class CfgHelper
    {
        private static Configuration cfg;

        #region Singleton

        private CfgHelper()
        {
            cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        private static CfgHelper _CfgHelper = null;

        public static CfgHelper Instance
        {
            get
            {
                if (_CfgHelper == null)
                {
                    _CfgHelper = new CfgHelper();
                }

                return _CfgHelper;
            }
        }

        #endregion

        public MonoSmsSection GetSection
        {
            get
            {
                MonoSmsSection section = cfg.Sections["monosms"] as MonoSmsSection;

                return section;
            }
        }

        public static void WriteNewConfiguration()
        {
            WriteConfiguration("usuario@monosms", "usuario", "mail.gigared.com");
        }

        public static void WriteConfiguration(string email, string user, string smtpServer)
        {
            Configuration configuration = GetConfiguration(GetFileName(null));
            configuration.Sections.Remove("monosms");
            MonoSmsSection section = new MonoSmsSection();
            section.Settings.Add(new NameValueConfigurationElement("user.email", email));
            section.Settings.Add(new NameValueConfigurationElement("user.name", user));
            section.Settings.Add(new NameValueConfigurationElement("smtp.server", smtpServer));

            configuration.Sections.Add("monosms", section);
            configuration.Save(ConfigurationSaveMode.Full);
        }

        private static Configuration GetConfiguration(string fileName)
        {
            //Not implemented in Mono Framework
            //return
            //  ConfigurationManager.OpenMappedExeConfiguration(GetExeConfigurationFileMap(fileName),
            //                                                  ConfigurationUserLevel.None);

            //for this reason I use this.
            return ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        private static ExeConfigurationFileMap GetExeConfigurationFileMap(string fileName)
        {
            ExeConfigurationFileMap map = new ExeConfigurationFileMap();
            map.ExeConfigFilename = fileName;
            return map;
        }

        public static string GetFileName(string fileName)
        {
            if ((fileName == null) || (fileName.Trim() == ""))
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string friendlyName = AppDomain.CurrentDomain.FriendlyName;
                fileName = string.Format("{0}{1}.config", baseDirectory, friendlyName);
            }
            return fileName;
        }
    }
}