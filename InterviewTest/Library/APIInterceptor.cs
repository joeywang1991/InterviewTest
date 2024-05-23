using Azure;
using Azure.Core;
using InterviewTest.Models;
using InterviewTest.Repositories;
using InterviewTest.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTest.Library
{
    public class APIInterceptor : IActionFilter
    {
        private readonly IServiceProvider _logger;
        public APIInterceptor(IServiceProvider logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Reqesut Log紀錄時取得的LogID
        /// </summary>
        private long? logID = null;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //取的API的Reqesut資料
            var requestModel = context.ActionArguments;
            var requestJson = JsonConvert.SerializeObject(requestModel); // 
            using (var scope = _logger.CreateScope())
            {
                var scopedService = scope.ServiceProvider.GetRequiredService<RecordLogService>();
                logID = scopedService.AddLog(requestJson);
            }

            //可以再此驗證API加密資料，驗證失敗直接回拋錯誤
            //可使用RSA+ASE的混合加密方式增加資料傳遞隱密性及安全性，但會需要多一個API交換REA公私鑰步驟
            //加密方式 可用 AES加密RequestBody，之後再將AES的key、iv轉Json字串用RSA公鑰加密
            //解密方式 將AES的Key、iv用RSA私鑰解密後，再用AES將RequestBody解密取得明碼電文
            //Response也可採用這種方式加密回傳會去
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //取的API的Reponse資料
            var responseModel = context.Result as ObjectResult;
            if (responseModel != null)
            {
                var responseJson = JsonConvert.SerializeObject(responseModel.Value);
                using (var scope = _logger.CreateScope())
                {
                    var scopedService = scope.ServiceProvider.GetRequiredService<RecordLogService>();
                    scopedService.UpdateLog(responseJson, logID);
                }
                Console.WriteLine($"Response Model: {responseJson}");
            }

        }

    }
}
