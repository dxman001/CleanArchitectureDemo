namespace Presentation.API.MiddleWares;
using Presentation.API.Dtos;
using System.Net;
using System.Text.Json;

public class GlobalExceptionHandler 
{
    private readonly RequestDelegate _next;
    public GlobalExceptionHandler(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch(Exception e)
        {   
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = e switch
            {
                BadHttpRequestException => (int)HttpStatusCode.BadRequest,
                KeyNotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError,

            };           
            await response.WriteAsync(JsonSerializer.Serialize(new ApiResponse(null, response.StatusCode, e.Message.ToString())));
        }
    }
}
