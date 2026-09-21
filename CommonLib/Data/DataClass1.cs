using CommonLib.Data.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Data
{
    public class DataClass1: IDataClass1
    {
        public async Task<string> GetUserDetails(HttpContext httpContext)
        {
            //httpContext.User.

            return "User role from middle ware";
        }

        public void InsertErrorLog(ErrorLogModel errorLogModel, ApplicationDbContext _context)
        {
            _context.ErrorLogs.Add(new ErrorLog()
            {
                Apiurl = errorLogModel.Apiurl,
                Path = errorLogModel.Path,
                Host = errorLogModel.Host,
                StackTrace = errorLogModel.StackTrace,
                RequestBody = errorLogModel.RequestBody,
                MethodType = errorLogModel.MethodType,
                Source = errorLogModel.Source,
                ExceptionMessage = errorLogModel.ExceptionMessage,
                CreatedOn = errorLogModel.CreatedOn
            });
            _context.SaveChanges();

        }
    }
}
