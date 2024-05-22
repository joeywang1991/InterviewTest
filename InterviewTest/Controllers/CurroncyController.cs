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


        [HttpGet("GetCurroncy")]
        public ActionResult GetCurroncy()
        {
            DataResult<List<GetCurrencyInfo>> result = _currentPriceService.GetCurrentInfo();

            return Ok(result);
        }

        [HttpPost("GetCurrentPrice")]        
        public ActionResult GetCurrentPrice(string currency, int options = 0)
        {
            DataResult<List<GetCurrencyInfo>> result = new DataResult<List<GetCurrencyInfo>>();
            // 取得API結果並更新資料庫
            var UpdateResult = _currentPriceService.UpdateCurrentPrice(currency);
            if (UpdateResult.IsSuccess)
            {
                return Ok(UpdateResult);
            }

            result = _currentPriceService.GetCurrentInfo();     

            return Ok(result);
        }

        [HttpPost("DeleteCurrencyData")]
        public ActionResult DeleteCurrencyData(string currency, int options = 0)
        { 
        
        
        
        
        
            return Ok(currency); 
        }
    }
}
