using System;
using System.Reflection;
using System.Windows.Forms;

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
        
//        	Assembly ourAssembly = Assembly.GetExecutingAssembly();
//        	        
//   	     	//Solo para debugging.
//           	string[] listResources = ourAssembly.GetManifestResourceNames();
//           
//           	foreach(string r in listResources)
//           	{
//           		Console.WriteLine("Resource name: {0}",r);                
//           	}
           
        

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}