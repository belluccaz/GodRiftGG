using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GodRift.API.Middleware
{
    public class GlobalExceptionHandler : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "An unhandled exception occurred.");

            var result = new ObjectResult(new
            {
                Message = "An error occurred while processing your request.",
                ExceptionMessage = context.Exception.Message
            })
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.Result = result;
        }
    }
}