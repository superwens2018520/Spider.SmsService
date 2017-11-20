using System;
using System.Collections.Generic;
using System.Linq;
using Spider.CommandApi.Enum;
using Spider.CommandApi.Model;
using Spider.CommandApi.Service;

namespace Spider.SmsService.Service
{
    public class SmsService : MarshalByRefObject, ISmsService
    {
        /// <summary>
        /// TODO 
        /// </summary>
        /// <param name="iccid"></param>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public List<SmsRecord> GetSmsRecords(string iccid, DateTime? startDateTime = null, DateTime? endDateTime = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO 
        /// </summary>
        /// <returns></returns>
        public List<SimDevice> GetSimRecords()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO 
        /// </summary>
        /// <param name="iccid"></param>
        /// <param name="smsRecordType"></param>
        /// <param name="Otp"></param>
        /// <param name="rDateTime"></param>
        /// <returns></returns>
        public SmsRecord GetSmsRecord(string iccid, SmsRecordType smsRecordType, string Otp, DateTime? rDateTime = null)
        {
            throw new NotImplementedException();
        }

        #region job

        /// <summary>
        ///     任务队列
        /// </summary>
        public static IDictionary<string, JobSmsOtp> JobList = new Dictionary<string, JobSmsOtp>();

        /// <summary>
        ///     是否已经在检查中如果任务尚未完成丢弃
        /// </summary>
        public static bool JobBusyFlag;

        /// <summary>
        ///     任务队列操作锁
        /// </summary>
        public static object JobListLock = new object();

        /// <summary>
        ///     执行任务
        /// </summary>
        public void DoJob()
        {
            if (JobBusyFlag)
            {
                return;
            }
            JobBusyFlag = true;
            try
            {
                List<JobSmsOtp> checkJobList;
                lock (JobListLock)
                {
                    //删除掉无效任务数据
                    JobList = JobList.Where(o => o.Value.OverDateTime > DateTime.Now)
                        .ToDictionary(x => x.Key, y => y.Value);

                    checkJobList = JobList.Values.ToList();
                }

                foreach (var jobSmsOtp in checkJobList)
                {
                    CheckJob(jobSmsOtp);
                }
            }
            catch (Exception)
            {
                //ig 允许执行任务过程中出现错误 
            }
            finally
            {
                JobBusyFlag = false;
            }
        }

        /// <summary>
        ///     TODO 这里需要进行实现
        ///     找到匹配的任务 调用远程接口 提交任务 从任务队列中删除
        /// </summary>
        /// <param name="jobSmsOtp"></param>
        private void CheckJob(JobSmsOtp jobSmsOtp)
        {
            //TODO 这里属于第二步工作内容  需要从sms 短信内容中解析出数据 ccid 找到对应的数据  然后使用 OtpRemark 和OtpDate 等参数进行查找和处理

            throw new NotImplementedException();

            //如果有比配对任务 直接处理掉并且从现有任务队列中移除
        }

        /// <summary>
        ///     添加任务请求
        /// </summary>
        /// <param name="obj"></param>
        public void AddOtpJob(JobSmsOtp obj)
        {
            //任务是否合法 如果不合法丢弃
            if (string.IsNullOrEmpty(obj?.MessageId))
            {
                return;
            }
            lock (JobListLock)
            {
                if (!JobList.ContainsKey(obj.MessageId))
                {
                    JobList.Add(obj.MessageId, obj);
                }
            }
        }


        public void RemoveJob(JobSmsOtp obj)
        {
            //任务是否合法 如果不合法丢弃
            if (string.IsNullOrEmpty(obj?.MessageId))
            {
                return;
            }
            lock (JobListLock)
            {
                if (JobList.ContainsKey(obj.MessageId))
                {
                    JobList.Remove(obj.MessageId);
                }
            }
        }

        #endregion
    }
}