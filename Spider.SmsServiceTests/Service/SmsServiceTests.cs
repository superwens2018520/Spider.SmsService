using System;
using System.Collections;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spider.CommandApi.Service;

namespace Spider.SmsService.Service.Tests
{
    [TestClass]
    public class SmsServiceTests
    {
        private ISmsService _smsService;

        public ISmsService SmsService
        {
            get
            {
                if (_smsService == null)
                {
                    //注册服务端通讯协议
                    var table3 = new Hashtable
                    {
                        {"port", 0},
                        {"typeFilterLevel", TypeFilterLevel.Full},
                        {"name", Guid.NewGuid().ToString()}
                    };

                    //注册TCP服务
                    var tcpChannel = new TcpChannel(table3, new BinaryClientFormatterSinkProvider(),
                        new BinaryServerFormatterSinkProvider {TypeFilterLevel = TypeFilterLevel.Full});
                    ChannelServices.RegisterChannel(tcpChannel, false);

                    try
                    {
                        //注册tcpchannel


                        _smsService = (ISmsService)
                            Activator.GetObject(typeof (ISmsService), "tcp://localhost:12009/SmsService");
                    }
                    catch (Exception)
                    {
                    }
                }


                return _smsService;
            }
        }

        /// <summary>
        ///     测试获得记录
        /// </summary>
        [TestMethod]
        public void GetSmsRecordsTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void GetSimRecordsTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void GetSmsRecordTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void DoJobTest()
        {
            Assert.Fail();
        }
    }
}