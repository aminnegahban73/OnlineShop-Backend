using Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace Web.Middleware
{
    public class ExceptionsHandlerMiddleware
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILoggerFactory _logger;
        private readonly RequestDelegate _next;

        public ExceptionsHandlerMiddleware(IWebHostEnvironment environment, ILoggerFactory logger, RequestDelegate next)
        {
            _environment = environment;
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                // Create default
                string result = HandleServerError(context, ex, options);
                // Change result
                result = HandleResult(context, ex, result, options);
                
                await context.Response.WriteAsync(result);
            }
        }

        private static string HandleServerError(HttpContext context, Exception ex, JsonSerializerOptions options)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(new ApiToReturn((int)HttpStatusCode.InternalServerError, ex.Message), options);
            return result;
        }

        private string HandleResult(HttpContext context, Exception ex, string result, JsonSerializerOptions options)
        {
            switch (ex)
            {
                case NotFoundEntityException notFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    result = JsonSerializer.Serialize(new ApiToReturn((int)HttpStatusCode.NotFound, notFoundException.Message, notFoundException.Messages, ex.Message), options);
                    break;
                case BadRequestEntityException badRequestException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(new ApiToReturn((int)HttpStatusCode.BadRequest, badRequestException.Message, badRequestException.Messages, ex.Message), options);
                    break;
                case ValidationEntityException validationEntityException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(new ApiToReturn((int)HttpStatusCode.BadRequest, validationEntityException.Message, validationEntityException.Messages, ex.Message), options);
                    break;
            }
            return result;
        }
    }
}
