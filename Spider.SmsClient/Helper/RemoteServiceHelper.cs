using System;
using Spider.CommandApi.Service;

namespace Spider.SmsClient.Helper
{
    public class RemoteServiceHelper
    {
        private ISmsService _smsService;

        public ISmsService SmsService
        {
            get
            {
                if (_smsService == null)
                {
                    try
                    {
                        //注册tcpchannel
                        _smsService = (ISmsService) Activator.GetObject(typeof (ISmsService), typeof (ISmsService).Name);
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