using InterviewTest.Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;
using InterviewTest.Models.Table;

namespace InterviewTest.Repositories
{
    public class LogRepository
    {
        private readonly MasterDBContext _repository;

        public LogRepository(MasterDBContext repository)
        {
            _repository = repository;
        }

        public long? AddLog(LogModel model)
        {
            try
            {
                // 建立輸入參數
                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@LogID", SqlDbType.Int) { Direction = ParameterDirection.Output},
                    new SqlParameter("@RequestHeader", SqlDbType.NVarChar, 512) { Direction = ParameterDirection.Input, Value = model.RequestHeader },
                    new SqlParameter("@RequestBody", SqlDbType.NVarChar, 512) { Direction = ParameterDirection.Input, Value = model.RequestBody }
                };

                //SQL部分直接寫在程式碼內會產生資安跟弱掃不過的議題，可採用下列幾種方法規避
                //1. 將SQL存在資料庫內用特定key去取得
                //2. 使用EXEC Stored Procedure
                //3. 將SQL用檔案另存檔的方式，再用特定關鍵字取得
                string sql = $"INSERT INTO dbo.Log_APILog(RequestTime, RequestHeader, RequestBody, ResponseTime, ResponseHeader, ResponseBody)" +
                    $"VALUES(GETDATE(), @RequestHeader, @RequestBody, null, null, null);" +
                    $" SET @LogID = @@IDENTITY";                

                // 執行原生 SQL
                _repository.Database.ExecuteSqlRaw(sql, parameters);

                // 讀取輸出參數的值
                var logId = Convert.ToInt32(parameters[0].Value);

                return logId;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while executing SQL query: {ex.Message}");
                return null;
            }
        }

        public void UpdateLog(LogModel model)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@LogID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = model.LogID},
                    new SqlParameter("@ResponseHeader", SqlDbType.NVarChar, 2048) { Direction = ParameterDirection.Input, Value = "" },
                    new SqlParameter("@ResponseBody", SqlDbType.NVarChar, 2048) { Direction = ParameterDirection.Input, Value = model.ResponseBody }
                };

                string sql = $"UPDATE Log_APILog " +
                    $"SET ResponseTime = GETDATE()," +
                    $"ResponseHeader = @ResponseHeader," +
                    $"ResponseBody = @ResponseBody " +
                    $"WHERE LogID = @LogID";
                _repository.Database.ExecuteSqlRaw(sql, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while executing SQL query: {ex.Message}");
            }
        }
    }

}
