using System;
using Spider.CommandApi.Service;
using static System.Configuration.ConfigurationSettings;

namespace Spider.SmsClient.Helper
{
    public class RemoteServiceHelper
    {
        private static ISmsService _smsService;

        public static string RemoteSmsServiceAddress
        {
            get
            {
                var url = AppSettings["SmsServiceAddress"];
                if (!(url.EndsWith("/") || url.EndsWith("\\")))
                {
                    url = url + "/";
                }
                return url;
            }
        }

        /// <summary>
        ///     SMS 服务
        /// </summary>
        public static ISmsService SmsService
        {
            get
            {
                if (_smsService == null)
                {
                    try
                    {
                        //注册tcpchannel
                        _smsService =
                            (ISmsService)
                                Activator.GetObject(typeof (ISmsService),
                                    RemoteSmsServiceAddress + typeof (ISmsService).Name);
                    }
                    catch (Exception)
                    {
                    }
                }

                return _smsService;
            }
        }
    }
}