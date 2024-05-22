using Azure.Core;
using InterviewTest.Models.Table;
using InterviewTest.Repositories;
using Newtonsoft.Json;
using System.Text;

namespace InterviewTest.Services
{
    public class RecordLogService
    {
        private readonly LogRepository _logRepository;

        public RecordLogService(LogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public long? AddLog(string body)
        {

            LogModel model = new LogModel()
            {
                RequestHeader = "", 
                RequestBody = body 
            };

            try
            {
                return _logRepository.AddLog(model);
            }
            catch (Exception ex)
            {
                // 若發生錯誤可以發送錯誤信但不可中斷API後續程式
                // send error mail
                return null;
            }
        }

        public void UpdateLog(string body, long? logId)
        {
            // 沒有logId代表上面log紀錄失敗，已發送錯誤信這邊不再發送
            if (logId == null) { return; }


            LogModel model = new LogModel()
            {
                LogID = (long)logId,
                ResponseHeader = "", 
                ResponseBody = body
            };

            try
            {
                _logRepository.UpdateLog(model);
            }
            catch (Exception ex)
            {
                // 若發生錯誤可以發送錯誤信但不可中斷API後續程式
                // send error mail

            }
        }
    }

}

