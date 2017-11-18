using System;
using System.Windows.Forms;
using static System.Runtime.Remoting.RemotingConfiguration;

namespace Spider.SmsClient
{
    internal static class Program
    {
        /// <summary>
        ///     应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //注册配置文件
            Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}