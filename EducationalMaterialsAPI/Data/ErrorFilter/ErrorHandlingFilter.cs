using Microsoft.AspNetCore.Mvc.Filters;

namespace EducationalMaterialsAPI.Data.ErrorFilter
{
    public class ErrorHandlingFilter : ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            ILogger logger = LoggerFactory.Create(x => x.AddConsole()).CreateLogger("ErrorHandlingFilter");
            logger.LogCritical(exception, "\n" +
                $"Exception message: {exception.Message} \n" +
                $"Stack trace:\n {exception.StackTrace}");

            context.HttpContext.Response.StatusCode = 500;
            context.ExceptionHandled = true; 
        }
    }
}
