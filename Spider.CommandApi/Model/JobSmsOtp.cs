using System;

namespace Spider.CommandApi.Model
{
    /// <summary>
    ///     短信OTP获取任务
    /// </summary>
    [Serializable]
    public class JobSmsOtp
    {
        /// <summary>
        /// </summary>
        public string MessageId { get; set; }

        /// <summary>
        ///     每一家银行对应的OTP 的格式都可能不一样
        /// </summary>
        public string BankId { get; set; }

        /// <summary>
        ///     CCID sim卡的唯一标识
        /// </summary>
        public string Ccid { get; set; }

        /// <summary>
        ///     有效时间
        ///     如果有效时间>当前时间 表示该任务已经超时 作废
        /// </summary>
        public DateTime OverDateTime { get; set; }

        /// <summary>
        ///     OTP remark 为短信内容中包含的数据
        /// </summary>
        public string OtpRemark { get; set; }

        /// <summary>
        ///     OTP datetime 为短信中包含的数据
        /// </summary>
        public string OtpDateTime { get; set; }


        /// <summary>
        ///     OTP 为任务需要获得到的OTP
        /// </summary>
        public string OtpResult { get; set; }
    }
}