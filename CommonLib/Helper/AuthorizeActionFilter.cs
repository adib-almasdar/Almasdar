using CommonLib.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Helper
{
    public class AuthorizeActionFilter: IAuthorizationFilter
    {
        private readonly string _permission;

        public AuthorizeActionFilter()
        {
            _permission = "";
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                UserModel userModel = CheckUserPermission(context.HttpContext);
                bool isAuthorized = userModel.IsAuthorized;

                if (!isAuthorized)
                {
                    context.Result = new UnauthorizedResult();
                    context.HttpContext.Response.Headers.Add("Role", userModel.Role);

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity();
                    Claim claim = new Claim(ClaimTypes.Role, "Rajaji");
                    claimsIdentity.AddClaim(claim);
                    context.HttpContext.User.AddIdentity(claimsIdentity);
                }
                else
                {
                    context.HttpContext.Response.Headers.Add("Role", userModel.Role);

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity();
                    Claim claim = new Claim(ClaimTypes.Role, "Rajaji");
                    claimsIdentity.AddClaim(claim);
                    context.HttpContext.User.AddIdentity(claimsIdentity);
                }
            }
            catch (Exception ex)
            {
                context.Result = new UnauthorizedResult();
                context.HttpContext.Response.Headers.Add("Role", "UnAuthorized");
            }

        }
        private UserModel CheckUserPermission(HttpContext httpContext)
        {
            // Logic for checking the user permission goes here. 
            var headers = httpContext.Request.Headers;

            string email = httpContext.Request.QueryString.Value.Split('=')[1];
            string endpoint = httpContext.Request.Path;

            UserModel userModel = new UserModel();
            userModel.Email= email;
            if (email.ToLower().Contains("admin"))
            {
                userModel.Name = "ADIB Admin";
                userModel.Role = "Admin";
            }
            else
            {
                userModel.Name = "ADIB User";
                userModel.Role = "User";
            }
           

            if (endpoint== "/api/ADIBTest" && (userModel.Role == "User" || userModel.Role == "Admin"))
            {
                userModel.IsAuthorized = true;
            }
            else if (endpoint == "/api/ADIBAdminData" && userModel.Role == "Admin")
            {
                userModel.IsAuthorized = true;
            }
            else
            {
                userModel.IsAuthorized = false;
            }

            return userModel;
        }
    }
}
