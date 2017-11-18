using System;
using System.Collections.Generic;
using Spider.CommandApi.Enum;
using Spider.CommandApi.Model;
using Spider.CommandApi.Service;

namespace Spider.SmsService.Service
{
    public class SmsService : MarshalByRefObject, ISmsService
    {
        public List<SmsRecord> GetSmsRecords(string iccid, DateTime? startDateTime = null, DateTime? endDateTime = null)
        {
            throw new NotImplementedException();
        }

        public List<SimDevice> GetSimRecords()
        {
            throw new NotImplementedException();
        }

        public SmsRecord GetSmsRecord(string iccid, SmsRecordType smsRecordType, string Otp, DateTime? rDateTime = null)
        {
            throw new NotImplementedException();
        }

        public void DoJob()
        {
            throw new NotImplementedException();
        }
    }
}