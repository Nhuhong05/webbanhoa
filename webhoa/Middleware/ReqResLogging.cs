using System.Text;

namespace webhoa.Middleware_
{
    public class ReqResLogging
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ReqResLogging> _logger;


        public ReqResLogging(RequestDelegate next, ILogger<ReqResLogging> loggerFactory)
        {
            _next = next;
            _logger = loggerFactory;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            // xem log client request
            _logger.LogInformation($"Client Request: {httpContext.Request.Method} {httpContext.Request.Path}");
            // lấy nội dunv của request body
            string requestBody = await GetRequestBody(httpContext.Request);
            // xem nội dung của request body
            _logger.LogInformation($"Client Request Body: {requestBody}");
            // lấy nội dung của response
            Stream originalResponseBody = httpContext.Response.Body;
            // tạo luồng bộ nhớ mới để ghi lại response
            using (var responseBody = new MemoryStream())
            {
                httpContext.Response.Body = responseBody;
                await _next(httpContext);
                string responseBodyString = await GetResponseBody(httpContext.Response);
                _logger.LogInformation($"Server Response Body: {responseBodyString}");
                httpContext.Response.Body = originalResponseBody;
                await responseBody.CopyToAsync(originalResponseBody);
            }
           
        }

        private async Task<string> GetResponseBody(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            string responseBody = await new StreamReader(response.Body, Encoding.UTF8).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);
            return responseBody;
        }

        private async Task<string> GetRequestBody(HttpRequest request)
        {
            request.EnableBuffering();
            using (StreamReader reader = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true))
            {
                string requestBody = await reader.ReadToEndAsync();
                request.Body.Position = 0;
                return requestBody;
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ReqResLoggingExtensions
    {
        public static IApplicationBuilder UseReqResLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ReqResLogging>();
        }
    }

}
