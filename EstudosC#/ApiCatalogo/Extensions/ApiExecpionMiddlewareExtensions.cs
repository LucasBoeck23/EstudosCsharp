using System.Diagnostics;
using System.Net;
using ApiCatalogo.Domain;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace ApiCatalogo.Extensions;

public static class ApiExecpionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if(contextFeature != null)
                {
                    await context.Response.WriteAsync(new ErrorDetails()
                    {
                           StatusCode = context.Response.StatusCode,
                           Message = contextFeature.Error.Message,
                           Trace = contextFeature.Error.StackTrace
                    }.ToString());

                }
            });
        });
    }
}
