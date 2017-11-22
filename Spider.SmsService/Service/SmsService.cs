using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using Spider.CommandApi.Enum;
using Spider.CommandApi.Model;
using Spider.CommandApi.Service;
using Spider.SmsService.Helper;

namespace Spider.SmsService.Service
{
    public class SmsService : MarshalByRefObject, ISmsService
    {
        public List<SmsRecord> GetSmsRecords(string iccid, DateTime? startDateTime = null, DateTime? endDateTime = null)
        {
            try
            {
                var timeInfo = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                var strSql = new StringBuilder("SELECT id, number, content, time, imsi, iccid, simnum FROM L_SMS WHERE 1 = 1 ");
                if (!string.IsNullOrEmpty(iccid))
                    strSql.Append(" AND iccid = " + iccid);
                strSql.Append(" AND time >= @Stime AND time <= @Etime");
                var commandParameters = new OleDbParameter[2];
                if (startDateTime != null)
                {
                    var dt = TimeZoneInfo.ConvertTimeFromUtc(TimeZoneInfo.ConvertTimeToUtc((DateTime)startDateTime),
                        timeInfo);
                    commandParameters[0] = new OleDbParameter("Stime", dt);
                }
                else
                {
                    var dt = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeInfo);
                    commandParameters[0] = new OleDbParameter("Stime", dt);
                }
                if (endDateTime != null)
                {
                    var dt = TimeZoneInfo.ConvertTimeFromUtc(TimeZoneInfo.ConvertTimeToUtc((DateTime)endDateTime),
                        timeInfo);
                    commandParameters[1] = new OleDbParameter("Etime", dt);
                }
                else
                {
                    var dt = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeInfo);
                    commandParameters[1] = new OleDbParameter("Etime", dt);
                }
                var ds = AccessHelper.ExecuteDataSet(AccessHelper.Conn + "SMS.mdb", strSql.ToString(), commandParameters);
                var list = new List<SmsRecord>();
                if (ds != null && ds.Tables.Count > 0)
                {
                    var dt = ds.Tables[0];
                    for (var i = 0; i < dt.Rows.Count; i++)
                    {
                        int id;
                        DateTime dateTime;
                        if (int.TryParse(dt.Rows[i]["id"].ToString(), out id) &&
                            DateTime.TryParse(dt.Rows[i]["time"].ToString(), out dateTime))
                        {
                            var entity = new SmsRecord
                            {
                                Id = id,
                                Number = dt.Rows[i]["number"].ToString(),
                                Content = dt.Rows[i]["content"].ToString(),
                                Time = dateTime,
                                Imsi = dt.Rows[i]["imsi"].ToString(),
                                Iccid = dt.Rows[i]["iccid"].ToString(),
                                Simnum = dt.Rows[i]["simnum"].ToString()
                            };
                            list.Add(entity);
                        }
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                LogHelper.Error("GetSmsRecords Error! Msg:" + ex.Message);
            }
            return null;
        }
        
        public List<SimDevice> GetSimRecords()
        {
            try
            {
                var strSql = new StringBuilder("SELECT id, Comport, phonum, imsi, iccid, imei FROM Devices WHERE 1 = 1 ");
                var ds = AccessHelper.ExecuteDataSet(AccessHelper.Conn + "OtInfo.mdb", strSql.ToString(), null);
                var list = new List<SimDevice>();
                if (ds != null && ds.Tables.Count > 0)
                {
                    var dt = ds.Tables[0];
                    for (var i = 0; i < dt.Rows.Count; i++)
                    {
                        int id;
                        if (int.TryParse(dt.Rows[i]["id"].ToString(), out id))
                        {
                            var entity = new SimDevice
                            {
                                Id = id,
                                Comport = dt.Rows[i]["Comport"].ToString(),
                                Phonum = dt.Rows[i]["phonum"].ToString(),
                                Imsi = dt.Rows[i]["imsi"].ToString(),
                                Iccid = dt.Rows[i]["iccid"].ToString(),
                                Imei = dt.Rows[i]["imei"].ToString()
                            };
                            list.Add(entity);
                        }
                    }
                }
                return list;

            }
            catch (Exception ex)
            {
                LogHelper.Error("GetSimRecords Error! Msg:" + ex.Message);
            }
            return null;
        }
        
        public SmsRecord GetSmsRecord(string iccid, SmsRecordType smsRecordType, string otp, DateTime? rDateTime = null)
        {
            try
            {
                var timeInfo = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                var strSql = new StringBuilder("SELECT id, number, content, time, imsi, iccid, simnum FROM L_SMS WHERE 1 = 1 ");
                if (!string.IsNullOrEmpty(iccid))
                    strSql.Append(" AND iccid = " + iccid);
                switch (smsRecordType)
                {
                    case SmsRecordType.AddMemberOtp:
                        //strSql.Append(" AND  =  ");
                        break;
                    case SmsRecordType.Balance:
                        //strSql.Append(" AND  =  ");
                        break;
                    case SmsRecordType.ConfirmWithdrawOtp:
                        //strSql.Append(" AND  =  ");
                        break;
                    case SmsRecordType.DelMemberOtp:
                        //strSql.Append(" AND  =  ");
                        break;
                    case SmsRecordType.SimBalance:
                        //strSql.Append(" AND  =  ");
                        break;
                    case SmsRecordType.WithdrawOtp:
                        //strSql.Append(" AND  =  ");
                        break;
                }
                if (!string.IsNullOrEmpty(otp))
                {
                    strSql.Append(" AND content like %" + otp + "% ");
                }
                var needParam = false;
                var commandParameters = new OleDbParameter[1];
                if (rDateTime != null)
                {
                    strSql.Append(" AND time = @time ");
                    var dt = TimeZoneInfo.ConvertTimeFromUtc(TimeZoneInfo.ConvertTimeToUtc((DateTime)rDateTime),
                        timeInfo);
                    commandParameters[0] = new OleDbParameter("time", dt);
                    needParam = true;
                }
                var ds = needParam
                    ? AccessHelper.ExecuteDataSet(AccessHelper.Conn + "SMS.mdb", strSql.ToString(), commandParameters)
                    : AccessHelper.ExecuteDataSet(AccessHelper.Conn + "SMS.mdb", strSql.ToString(), null);
                if (ds != null && ds.Tables.Count > 0)
                {
                    var dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        int id;
                        DateTime dateTime;
                        if (int.TryParse(dt.Rows[0]["id"].ToString(), out id) &&
                            DateTime.TryParse(dt.Rows[0]["time"].ToString(), out dateTime))
                        {
                            return new SmsRecord
                            {
                                Id = id,
                                Number = dt.Rows[0]["number"].ToString(),
                                Content = dt.Rows[0]["content"].ToString(),
                                Time = dateTime,
                                Imsi = dt.Rows[0]["imsi"].ToString(),
                                Iccid = dt.Rows[0]["iccid"].ToString(),
                                Simnum = dt.Rows[0]["simnum"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("GetSmsRecord Error! Msg:" + ex.Message);
            }
            return null;
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