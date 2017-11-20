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