using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Mono.Sms.Core.Cfg;

namespace Mono.Sms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //CfgHelper.CreateEmpty(CfgHelper.GetFileName(null));

            //MonoSmsSection section = Mono.Sms.Core.Cfg.CfgHelper.Instance.GetSection;
        
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}