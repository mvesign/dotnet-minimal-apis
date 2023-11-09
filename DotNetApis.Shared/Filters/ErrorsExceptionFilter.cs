using System.Net;
using DotNetApis.Shared.Exceptions;
using DotNetApis.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DotNetApis.Shared.Filters;

/// <inheritdoc />
public class ErrorsExceptionFilter : IExceptionFilter
{
    /// <inheritdoc />
    public void OnException(ExceptionContext context)
    {
        if (context.ExceptionHandled)
            return;

        var statusCode = context.Exception switch
        {
            NotFoundException => HttpStatusCode.NotFound,
            InvalidModelException => HttpStatusCode.BadRequest,
            ArgumentNullException => HttpStatusCode.BadRequest,
            _ => HttpStatusCode.InternalServerError
        };

        var messages = new[]
        {
            statusCode != HttpStatusCode.InternalServerError
                ? context.Exception.Message
                : "Something bad has happened!"
        };

        if (context.Exception is InvalidModelException invalidModelException)
            messages = invalidModelException.Messages ?? messages;
        
        context.ExceptionHandled = true;
        context.Result = new ObjectResult(new ApiError(messages))
        {
            StatusCode = (int?)statusCode
        };
    }
}