using System;
using System.Diagnostics;
using Spider.SmsService.Helper;
using static System.Runtime.Remoting.RemotingConfiguration;

namespace Spider.GsmModemServer
{
    internal static class Program
    {
        /// <summary>
        ///     应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Console.WriteLine($"Start Modem Service");
            //注册配置文件
            Configure(Process.GetCurrentProcess().MainModule.FileName + ".config", false);

            //开启短信服务器
            SmsServiceHelper.StartService();

            do
            {
            } while (Console.ReadLine() != "exit");
        }
    }
}