namespace Presentation.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

public class ApiResponse : ResponseDto<object>
{
    public ApiResponse(object? data, int statusCode = StatusCodes.Status200OK, string? error = null)
        : base(data, statusCode, error)
    {

    }
    
}
public class ResponseDto<T> : IActionResult, IDisposable, IStatusCodeActionResult
{
    public T? Data { get; set; }
    public int? StatusCode { get; set; }
    public string? Error { get; set; }

    public ResponseDto(T? data, int statusCode = StatusCodes.Status200OK, string? error = null)
    {
        Data = data;
        StatusCode = statusCode;
        Error = error;
    }

    public async Task ExecuteResultAsync(ActionContext context) =>
        await new OkObjectResult(this).ExecuteResultAsync(context);
    public void Dispose()
    {
        if (Data != null && typeof(T).GetInterfaces().Contains(typeof(IDisposable)))
        {
            ((IDisposable)Data).Dispose();
        }
    }

}
