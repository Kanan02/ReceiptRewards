using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ReceiptRewards.Domain;
using ReceiptRewards.Domain.Responses;

namespace ReceiptRewards.App.Helpers;

public class ErrorHandlingMiddleware
{
    private readonly ILogger _logger;
    private readonly RequestDelegate next;

    public ErrorHandlingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    {
        this.next = next;
        _logger = loggerFactory.CreateLogger<ErrorHandlingMiddleware>();
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        _logger.LogError(ex.ToString());
        var code = HttpStatusCode.OK; //ex is CustomException ? HttpStatusCode.BadRequest : HttpStatusCode.InternalServerError;

        var errorMsg = SetErrorKeywordByExType(ex);

        var result = JsonConvert.SerializeObject(
            new ApiResponse(new ApiError { ErrorCode = "Errors.setError", ErrorMsg = errorMsg }),
            new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }
        );
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(result);
    }

    private string SetErrorKeywordByExType(Exception ex)
    {
        return ex.Message;
    }
}
