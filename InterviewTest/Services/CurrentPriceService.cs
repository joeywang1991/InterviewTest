using RestSharp;
using InterviewTest.Models;
using Newtonsoft.Json;
using InterviewTest.Repositories;
using InterviewTest.Library;
using InterviewTest.Models.Table;
using System.Collections.Generic;

namespace InterviewTest.Services
{
    public class CurrentPriceService
    {
        private readonly CurrancyRepository _currancyRepository;

        public CurrentPriceService(CurrancyRepository currancyRepository)
        {
            _currancyRepository = currancyRepository;
        }

        /// <summary>
        /// 取得當前幣別價格
        /// </summary>
        /// <returns></returns>
        public DataResult<CurrentPriceResponse> UpdateCurrentPrice(string currency)
        {
            DataResult<CurrentPriceResponse> result = new DataResult<CurrentPriceResponse>();
            string url = "https://api.coindesk.com/v1/bpi/currentprice.json";
            var client = new RestClient(url);
            var request = new RestRequest("", Method.Get);

            CurrentPriceResponse response = new CurrentPriceResponse();

            try
            {
                /// 之後可以用currency擴充呼叫其他貨幣的匯率API
                var callAPI = client.Execute(request);
                if (callAPI.IsSuccessful)
                {
                    response = JsonConvert.DeserializeObject<CurrentPriceResponse>(callAPI.Content);
                    result.SetSuccess(response);
                }
                else
                {
                    result.SetError(callAPI.Content);
                    return result;
                }

                List<CurrencyInfo> currentInfoList = new List<CurrencyInfo>() { response.Bpi.USD, response.Bpi.GBP, response.Bpi.EUR };
                _currancyRepository.UpdateCurrency(currentInfoList, currency);
                return result;
            }
            catch (Exception ex)
            {
                //系統錯誤發信通知
                //result.SetError(ex.ToString());
                result.SetError("幣別價格取得失敗!");
                return result;
            }
        }

        public DataResult<List<GetCurrencyInfo>> GetCurrentInfo()
        {
            DataResult<List<GetCurrencyInfo>> result = new DataResult<List<GetCurrencyInfo>>();

            try
            {
                List<GetCurrencyInfo> listCurrencyInfo = _currancyRepository.GetCurrencyInfo();
                if (listCurrencyInfo.Count == 0)
                {
                    result.SetError("查無此資料");
                }
                else
                {
                    result.SetSuccess(listCurrencyInfo);
                }
            }
            catch
            {
                result.SetError("查詢發生錯誤");
            }

            return result;
        }

    }
}
