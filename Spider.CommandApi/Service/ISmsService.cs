using System;
using System.Collections.Generic;
using Spider.CommandApi.Enum;
using Spider.CommandApi.Model;

namespace Spider.CommandApi.Service
{
    /// <summary>
    ///     主要实现短信相关功能
    /// </summary>
    public interface ISmsService
    {
        /// <summary>
        ///     读取所有手机短信
        /// </summary>
        /// <param name="iccid">sim卡ICCID 唯一 如果iccid 为空默认读取所有短信</param>
        /// <param name="startDateTime">开始时间 如果为空默认时间为当天GMT+7 </param>
        /// <param name="endDateTime">结束时间 如果为空默认为当天GMT+7</param>
        /// <returns></returns>
        List<SmsRecord> GetSmsRecords(string iccid = "", DateTime? startDateTime = null, DateTime? endDateTime = null);


        /// <summary>
        ///     返回当前设备所支持的所有Sim数据
        /// </summary>
        /// <returns></returns>
        List<SimDevice> GetSimRecords();


        /// <summary>
        ///     查询指定ICCID 对应的OTP
        /// </summary>
        /// <param name="iccid">SIM卡唯一ICCID</param>
        /// <param name="smsRecordType">查询类型</param>
        /// <param name="Otp">短信中包含字符</param>
        /// <param name="rDateTime">短信接受时间</param>
        /// <returns></returns>
        SmsRecord GetSmsRecord(string iccid, SmsRecordType smsRecordType, string Otp, DateTime? rDateTime = null);

        /// <summary>
        ///     开始执行任务
        /// </summary>
        void DoJob();
    }
}