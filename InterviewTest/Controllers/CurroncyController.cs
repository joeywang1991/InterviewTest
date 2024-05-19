using Microsoft.AspNetCore.Mvc;
using InterviewTest.Services;
using InterviewTest.Models;
using Newtonsoft.Json;


namespace InterviewTest.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CurroncyController : ControllerBase
    {
        private readonly ILogger<CurroncyController> _logger;

        public CurroncyController(ILogger<CurroncyController> logger)
        {
            _logger = logger;
        }


        [HttpGet("GetCurroncy")]
        public IActionResult GetCurroncy()
        {
            string ss = "OK sd4a56sd4a6s54da";

            return Ok(ss);
        }

        [HttpPost("GetCurrentPrice")]
        public string GetCurrentPrice(string ss = ":3")
        {
            CurrentPriceService currentPriceService = new CurrentPriceService();

            var result = currentPriceService.GetCurrentPrice();

            return result.Success ? JsonConvert.SerializeObject(result.Data) : result.ErrorMessage;
        }

    }
}
