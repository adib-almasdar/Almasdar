using CommonLib.Data.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDataClass1 _dataClass1;

        public RequestMiddleware(RequestDelegate next, IDataClass1 dataClass1)
        {
            _next = next;
            _dataClass1 = dataClass1;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                string userRole = await _dataClass1.GetUserDetails(context);
                context.Response.Headers.Add("Role_from_Request_Middleware", userRole);

                // Call the next delegate/middleware in the pipeline.
                await _next(context);
            }
            catch (Exception ex)
            {
				context.Response.StatusCode = 500;
				await context.Response.WriteAsync(ex.Message + ex.StackTrace);

			}

		}
    }

    public static class RequestRequestMiddlewareExtensions
    {
        public static IApplicationBuilder CallRequestMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestMiddleware>();
        }
    }
}
