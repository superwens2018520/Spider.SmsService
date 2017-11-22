using System;
using System.Runtime.Remoting;
using System.Threading;
using Spider.CommandApi.Service;

namespace Spider.SmsService.Helper
{
    /// <summary>
    ///     短信服务器
    /// </summary>
    public class SmsServiceHelper
    {
        /// <summary>
        ///     任务定时器
        /// </summary>
        public static Timer JobTimer;


        public static bool CheckJobFlag;

        /// <summary>
        ///     短信莫服务器
        /// </summary>
        public static ISmsService SmsService { get; set; }

        /// <summary>
        ///     开启
        /// </summary>
        public static void StartService()
        {
            if (SmsService == null)
            {
                //代码方式注册服务
                try
                {
                    Console.WriteLine($"Open Public SmsService:{typeof(ISmsService).Name}");
                    //注册服务端
                    RemotingConfiguration.RegisterWellKnownServiceType(typeof(Service.SmsService),
                        typeof(ISmsService).Name, WellKnownObjectMode.Singleton);
                    Console.WriteLine($"Open Public SmsService:Success");
                }
                catch (Exception)
                {
                    Console.WriteLine($"Open Public SpiderHostService:Fail");
                }

                SmsService = new Service.SmsService();
            }

            //系统定时秒钟执行一次检查任务
            if (JobTimer == null)
            {
                JobTimer = new Timer(s =>
                {
                    if (CheckJobFlag)
                    {
                        return;
                    }
                    try
                    {
                        CheckJobFlag = true;
                        SmsService.DoJob();
                    }
                    finally
                    {
                        CheckJobFlag = false;
                    }
                },null,2000,2000);
            }
        }
    }
}