namespace GeoInfo.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Mvc;
    using System.Net;
    using GeoInfo.Models;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly bool _isProductionEnv;

        public CustomExceptionFilterAttribute(IHostEnvironment environment) =>
            _isProductionEnv = environment.IsProduction();

        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.ContentType = "application/json";

            switch (context.Exception)
            {
                case NotFoundException:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    context.Result = new NotFoundObjectResult(BuildErrorMessage(context.Exception));
                    break;
                default:
                    var result = new ObjectResult(BuildErrorMessage(context.Exception))
                    {
                        StatusCode = (int)HttpStatusCode.InternalServerError
                    };
                    context.Result = result;
                    break;
            }
        }

        private string BuildErrorMessage(Exception exception)
        {

            var responseErrors = new List<string> { exception.Message };

            if (_isProductionEnv != true && !string.IsNullOrEmpty(exception.StackTrace))
            {
                responseErrors.Add(exception.StackTrace);
            }

            return string.Join(";", responseErrors);
        }
    }
}