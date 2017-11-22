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
        /// <param name="otp">短信中包含字符</param>
        /// <param name="rDateTime">短信接受时间</param>
        /// <returns></returns>
        SmsRecord GetSmsRecord(string iccid, SmsRecordType smsRecordType, string otp, DateTime? rDateTime = null);

        /// <summary>
        /// 开始执行任务
        /// 系统会在指定时间内触发该任务
        /// </summary>
        void DoJob();


        /// <summary>
        /// 添加一个Otp请求任务 
        /// 该方法由远程客户端进行调用
        /// 调用后本地会创建一个检查任务
        /// 当SMS系统中获得到与该任务匹配的数据后 
        /// 系统调用远程服务功能将数据提交到远程服务器中
        /// </summary>
        /// <returns></returns>
        void AddOtpJob(JobSmsOtp job);
    }
}