using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTest.Services
{
    public class InterceptorMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public InterceptorMiddleware(RequestDelegate requestDelegate) { 
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            // 记录请求日志
            var requestLog = $"{DateTime.Now} - Request: {context.Request.Method} {context.Request.Path}{context.Request.QueryString}";
            Console.WriteLine(requestLog);

            // 执行下一个中间件
            await _requestDelegate(context);

            // 记录响应日志
            var responseLog = $"{DateTime.Now} - Response: {context.Response.StatusCode}";
            Console.WriteLine(responseLog);
        }        
    }
}
