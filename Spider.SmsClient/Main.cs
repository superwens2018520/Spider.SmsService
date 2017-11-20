using System;
using System.Threading;
using System.Windows.Forms;
using Spider.SmsClient.Helper;

namespace Spider.SmsClient
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            //这里按照GMT+7 时区显示数据
            //-5分钟 为兼容时间设定
            dateTimePicker1.Value = DateTime.Now.AddHours(-1).AddMinutes(-5);
            dateTimePicker2.Value = DateTime.Now;
            CCID_txt.TextChanged += CCID_txt_TextChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //注意：不允许阻塞当前主线程
            ThreadPool.QueueUserWorkItem(s =>
            {
                //异步线程操作UI线程 需要使用委托方式
                BeginInvoke((EventHandler) delegate { BindSmsRecord(); });
            });
        }


        /// <summary>
        ///     根据UI 中提供的筛选条件 从远程服务中获得数据并且显示出来
        /// </summary>
        private void BindSmsRecord()
        {
            //TODO  这里调用远程接口数据 用来显示短信内容 到list中
            //注意：短信内容 根据短信id 从大到小进行排序 也可以理解成  最新的消息优先显示
            var smsList = RemoteServiceHelper.SmsService.GetSmsRecords(CCID, dateTimePicker1.Value,
                dateTimePicker2.Value);
        }

        #region CCID 

        private void CCID_txt_TextChanged(object sender, EventArgs e)
        {
            CCID = CCID_txt.Text;
        }

        /// <summary>
        ///     CCID
        /// </summary>
        public string CCID { get; set; }

        #endregion
    }
}