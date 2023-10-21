using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MTEFDataAccess.Model;
using System.Net;
using System.Text.Json;

namespace MTEFDataAccess.MiddleWares
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                _logger.LogError(error, message: error.Message);

                var response = context.Response;
                response.ContentType = "application/json";
                string? errorMessage = null;

                switch (error)
                {
                    case ArgumentException e:
                        errorMessage = e.Message;
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case TaskCanceledException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        errorMessage = "Operation Cancelled";
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(Response<string>.Fail
                    (errorMessage ?? "An error occured, we are working on it"));

                await response.WriteAsync(result);
            }
        }
    }
}
