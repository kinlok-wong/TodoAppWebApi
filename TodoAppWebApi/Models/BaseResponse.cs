using System;

namespace TodoAppWebApi.Models;

public class BaseResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;

    public void SetError(string message)
    {
        Success = false;
        Message = message;
    }
}
