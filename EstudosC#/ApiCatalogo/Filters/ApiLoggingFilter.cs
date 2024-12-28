using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiCatalogo.Filters;

public class ApiLoggingFilter : IActionFilter
{
    public readonly ILogger<ApiLoggingFilter> _logger;
    public ApiLoggingFilter(ILogger<ApiLoggingFilter> logger)
    {
        _logger = logger;
    }

    //Executa antes da action
    public void OnActionExecuting(ActionExecutingContext context)
    {
        _logger.LogInformation("********EXECUTANDO**********");
        _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
        _logger.LogInformation($"ModelState: {context.ModelState.IsValid}");
    }
    //Executa depois
    public void OnActionExecuted(ActionExecutedContext context)
    {
        _logger.LogInformation("********EXECUTADO**********");
        _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
        _logger.LogInformation($"ModelState: {context.ModelState.IsValid}");
    }

}
