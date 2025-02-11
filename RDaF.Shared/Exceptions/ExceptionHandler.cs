using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace RDaF.Shared.Exceptions
{
    public static class ExceptionHandler
    {
        public static void UseApiExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {

                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exceptionType = contextFeature.Error.GetType();
                    var domainExp = typeof(DomainException);
                    //if any exception then report it and log it
                    if (contextFeature != null)
                    {
                        if (exceptionType == typeof(DomainException))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            var isAjax = context.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
                            if (!isAjax)
                            {
                                context.Response.Redirect("/error");
                            }

                            //Business exception - exit gracefully
                            await context.Response.WriteAsync(new ErrorDetails()
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = contextFeature.Error.Message.ToString()
                            }.ToString()); ;
                        }
                        //Technical Exception for troubleshooting
                        //var logger = loggerFactory.CreateLogger("*");

                        //var userName = context.Request.HttpContext.User.Identity.Name;
                        //var claimsIdentity = (ClaimsIdentity)context.Request.HttpContext.User.Identity;
                        //var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

                        //logger.LogError($"UserId: {userId} UserName:{userName} \nError: {contextFeature.Error}");
                        else
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            var isAjax = context.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
                            if (!isAjax)
                            {
                                context.Response.Redirect("/error");
                            }

                            //Business exception - exit gracefully
                            await context.Response.WriteAsync(new ErrorDetails()
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = "Xəta baş verdi."
                            }.ToString());
                        }

                    }
                });
            });
        }
    }
}
