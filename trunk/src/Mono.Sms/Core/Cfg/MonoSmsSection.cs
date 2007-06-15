using System.Configuration;

namespace Mono.Sms.Core.Cfg
{
    public class MonoSmsSection : ConfigurationSection
    {
        [ConfigurationProperty("settings", IsDefaultCollection = false)]
        public NameValueConfigurationCollection Settings
        {
            get
            {
                NameValueConfigurationCollection settings = (NameValueConfigurationCollection) base["settings"];
                return settings;
            }
        }

        protected override string SerializeSection(ConfigurationElement parentElement, string name,
                                                   ConfigurationSaveMode saveMode)
        {
            string s = base.SerializeSection(parentElement, name, saveMode);
            return s;
        }
    }
}