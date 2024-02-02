using Application.Common.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using JsonSerializer = System.Text.Json.JsonSerializer;
using ValidationException = Application.Common.Exceptions.ValidationException;

namespace Presentation.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            await ExceptionHandler(context, e);
        }
    }

    private async Task ExceptionHandler(HttpContext context, Exception exception)
    {
        int statusCode = StatusCodes.Status500InternalServerError;
        string result = "Server error";
        switch (exception)
        {
            case ValidationException ex:
                statusCode = StatusCodes.Status400BadRequest;
                result = JsonConvert.SerializeObject(ex.Errors);
                break;
            case NotFoundException ex:
                statusCode = StatusCodes.Status404NotFound;
                Log.Error(ex.Message);
                result = JsonConvert.SerializeObject(ex.Error);
                break;
            case IdentityException ex:
                statusCode = StatusCodes.Status401Unauthorized;
                result = JsonConvert.SerializeObject(ex.Errors);
                break;
        }
        
        Log.Error(exception.Message);
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsync(result);
    }
}