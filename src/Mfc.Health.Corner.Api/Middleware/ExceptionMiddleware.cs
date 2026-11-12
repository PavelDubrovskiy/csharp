using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Common;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {

               // httpContext.Response.ContentType = "application/json";

               // httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var error = OperationResult.Error(ex);

                var errorSerializer = JsonConvert.SerializeObject(error);

                await httpContext.Response.WriteAsync(errorSerializer);
            }
        }
    }
}
