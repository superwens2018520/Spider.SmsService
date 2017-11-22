using System;

namespace Spider.CommandApi.Model
{
    /// <summary>
    /// 短信实体类
    /// sms.mdb 中的L_SMS
    /// </summary>
    [Serializable]
    public class SmsRecord
    {
        /// <summary>流水记录编号</summary>
        public int Id { get; set; }

        /// <summary>编号</summary>
        public string Number { get; set; }

        /// <summary>短信内容</summary>
        public string Content { get; set; }

        /// <summary>短信接收时间</summary>
        public DateTime? Time { get; set; }

        /// <summary>IMSI</summary>
        public string Imsi { get; set; }

        /// <summary>ICCID</summary>
        public string Iccid { get; set; }

        /// <summary>电话号码</summary>
        public string Simnum { get; set; }
    }
}