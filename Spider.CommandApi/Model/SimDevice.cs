using System;

namespace Spider.CommandApi.Model
{
    /// <summary>
    ///     SIM 卡信息
    ///     OtInfo.mdb 中的Devices
    /// </summary>
    [Serializable]
    public class SimDevice
    {
        public string Ccid { get; set; }

        //....
    }
}