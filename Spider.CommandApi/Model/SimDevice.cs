using System;

namespace Spider.CommandApi.Model
{
    /// <summary>
    /// SIM 卡信息
    /// OtInfo.mdb 中的Devices
    /// </summary>
    [Serializable]
    public class SimDevice
    {
        /// <summary>流水ID</summary>
        public int Id { get; set; }

        /// <summary>端口</summary>
        public string Comport { get; set; }

        /// <summary>电话号码</summary>
        public string Phonum { get; set; }

        /// <summary>IMSI</summary>
        public string Imsi { get; set; }

        /// <summary>ICCID</summary>
        public string Iccid { get; set; }

        /// <summary>IMEI</summary>
        public string Imei { get; set; }
    }
}