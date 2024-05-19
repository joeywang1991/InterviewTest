using RestSharp;
using InterviewTest.Models;
using Newtonsoft.Json;

namespace InterviewTest.Services
{
    public class CurrentPriceService
    {
        /// <summary>
        /// 取得當前幣別價格
        /// </summary>
        /// <returns></returns>
        public DataResult<CurrentPriceResponse> GetCurrentPrice()
        {
            DataResult<CurrentPriceResponse> result = new DataResult<CurrentPriceResponse>();
            string url = "https://api.coindesk.com/v1/bpi/currentprice.json";
            var client = new RestClient(url);
            var request = new RestRequest("", Method.Get);

            try
            {
                var callAPI = client.Execute(request);
                if (callAPI.IsSuccessful)
                {
                    CurrentPriceResponse response = JsonConvert.DeserializeObject<CurrentPriceResponse>(callAPI.Content);
                    result.SetSuccess(response);
                }
                else
                {
                    result.SetError(callAPI.Content);
                }

                return result;
            }
            catch (Exception ex)
            {
                result.SetError(ex.ToString());
                return result;
            }
        }
    }
}
