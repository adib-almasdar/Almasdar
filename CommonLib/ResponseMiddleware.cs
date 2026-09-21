using Azure.Core;
using CommonLib.Data;
using CommonLib.Data.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public class ResponseMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDataClass1 _dataClass1;
        public ResponseMiddleware(RequestDelegate next, IDataClass1 dataClass1)
        {
            _next = next;
            _dataClass1 = dataClass1;
        }

        public async Task InvokeAsync(HttpContext context,ApplicationDbContext applicationDbContext)
        {
            try
            {
                string userRole = await _dataClass1.GetUserDetails(context);
                context.Response.Headers.Add("Role_from_Response_Middleware", userRole);

                ClaimsIdentity claimsIdentity = new ClaimsIdentity();
                Claim claim = new Claim(ClaimTypes.Role, "HRManager");
                claimsIdentity.AddClaim(claim);
                context.User.AddIdentity(claimsIdentity);

                // Call the next delegate/middleware in the pipeline.
                await _next(context);
            }
            catch (Exception ex)
            {
                //Log Error in DB

                ErrorLogModel errorLogModel = new ErrorLogModel();
                errorLogModel.Apiurl = context.Request.Host + context.Request.Path;
                errorLogModel.Path = context.Request.Path;
                errorLogModel.Host = Convert.ToString(context.Request.Host);
                errorLogModel.StackTrace = Convert.ToString(ex.StackTrace);
                errorLogModel.RequestBody = Convert.ToString(context.Request.Body);
                errorLogModel.MethodType = Convert.ToString(context.Request.Method);
                errorLogModel.Source = Convert.ToString(ex.Source);
                errorLogModel.ExceptionMessage = Convert.ToString(ex.Message);
                errorLogModel.CreatedOn = DateTime.UtcNow;

                _dataClass1.InsertErrorLog(errorLogModel, applicationDbContext);

                if (ex.Message.Contains("No authenticationScheme was specified, and there was no DefaultChallengeScheme found"))
                {
                    context.Response.StatusCode = 401;
                    context.Response.Headers.Add("Role", "UnAuthorized");
                }
                else
                {
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync(ex.Message + ex.StackTrace);

                }
            }
           
        }

    }

    public static class RequestResponseMiddlewareExtensions
    {
        public static IApplicationBuilder CallResponseMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResponseMiddleware>();
        }
    }
}