using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using GeoInfo.Models;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exceptionMessage = string.Empty;

        if (context.Exception is NotFoundException)
        {
            exceptionMessage = context.Exception.Message;
        }
    }
}