using System.Text.Json;
using Application.Common.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

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
                result = JsonSerializer.Serialize(ex.Errors);
                break;
            case NotFoundException ex:
                statusCode = StatusCodes.Status404NotFound;
                result = JsonSerializer.Serialize(ex);
                break;
            case IdentityException ex:
                result = JsonSerializer.Serialize(ex.Errors);
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsync(result);
    }
}