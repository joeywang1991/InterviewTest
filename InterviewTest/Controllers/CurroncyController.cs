using Microsoft.AspNetCore.Mvc;
using InterviewTest.Services;
using InterviewTest.Repositories;
using Newtonsoft.Json;
using InterviewTest.Models;
using Microsoft.EntityFrameworkCore;
using InterviewTest.Library;
using InterviewTest.Models.Table;


namespace InterviewTest.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CurroncyController : ControllerBase
    {
        private readonly ILogger<CurroncyController> _logger;
        private readonly CurrentPriceService _currentPriceService;

        public CurroncyController(ILogger<CurroncyController> logger, CurrentPriceService currentPriceService)
        {
            _logger = logger;
            _currentPriceService = currentPriceService;
        }

        /// <summary>
        /// 取得 幣別匯率資料
        /// </summary>
        /// <param name="currency"></param>
        /// <param name="language"></param>
        /// <param name="throwError"></param>
        /// <returns></returns>
        [HttpGet("GetCurroncy")]
        public ActionResult GetCurroncy(string currency = "Bitcoin", string language = "zh-tw", bool throwError = false)
        {
            DataResult<List<GetCurrencyInfo>> result = _currentPriceService.GetCurrentInfo(currency, language, throwError);

            return Ok(result);
        }

        /// <summary>
        /// 更新 幣別匯率資料
        /// </summary>
        /// <param name="currency"></param>
        /// <param name="throwError"></param>
        /// <returns></returns>
        [HttpPost("UpdateCurrentPrice")]        
        public ActionResult UpdateCurrentPrice(string currency = "Bitcoin", bool throwError = false)
        {
            DataResult<List<GetCurrencyInfo>> result = new DataResult<List<GetCurrencyInfo>>();
            // 取得API結果並更新資料庫
            var UpdateResult = _currentPriceService.UpdateCurrentPrice(currency, throwError);
            if (UpdateResult.IsSuccess)
            {
                return Ok(UpdateResult);
            }

            result = _currentPriceService.GetCurrentInfo(throwError: throwError);     

            return Ok(result);
        }

        /// <summary>
        /// 刪除 幣別匯率資料
        /// </summary>
        /// <param name="currency"></param>
        /// <param name="throwError"></param>
        /// <returns></returns>
        [HttpPost("DeleteCurrencyData")]
        public ActionResult DeleteCurrencyData(string currency, bool throwError = false)
        { 
            DataResult result = new DataResult();

            result = _currentPriceService.DeleteCurrencyData(currency, throwError);            
        
            return Ok(result); 
        }
    }
}
