using InterviewTest.Library;
using InterviewTest.Models;
using InterviewTest.Models.Table;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace InterviewTest.Repositories
{
    public class CurrancyRepository
    {
        private readonly MasterDBContext _repository;

        public CurrancyRepository(MasterDBContext repository)
        {
            _repository = repository;
        }

        public DataResult UpdateCurrency(List<CurrencyInfo> currentInfoList, string currency = "Bitcoin")
        {
            DataResult result = new DataResult();

            // 建立 DataTable 並填入資料
            DataTable CurrentInfoTable = new DataTable();
            CurrentInfoTable.Columns.Add("CurrencyName", typeof(string));
            CurrentInfoTable.Columns.Add("Symbol", typeof(string));
            CurrentInfoTable.Columns.Add("Rate", typeof(decimal));
            CurrentInfoTable.Columns.Add("Description", typeof(string));
            CurrentInfoTable.Columns.Add("ExchangeCurrencyName", typeof(string));

            foreach (var item in currentInfoList)
            {
                if (item != null)
                {
                    CurrentInfoTable.Rows.Add(item.Code, item.Symbol, item.Rate_float, item.Description, currency);
                }
            }

            // 建立TableType
            var currentInfoParameters = new SqlParameter("@CurrentInfoList", SqlDbType.Structured)
            {
                TypeName = "dbo.CurrentInfoType",
                Value = CurrentInfoTable
            };

            // 呼叫SP，指定在 master 資料庫中
            _repository.Database.ExecuteSqlRaw("EXEC dbo.Currency_UpdateCurrencyInfo_U @CurrentInfoList", currentInfoParameters);

            return result;
        }

        /// <summary>
        /// 取得所有幣別
        /// </summary>
        /// <returns></returns>
        public List<GetCurrencyInfo> GetCurrencyInfo()
        {
            string execSql = "EXEC dbo.Currency_GetCurrencyInfo_S";
                        
            return _repository.GetCurrencyInfo.FromSqlRaw(execSql).ToList();
        }
    }
}
