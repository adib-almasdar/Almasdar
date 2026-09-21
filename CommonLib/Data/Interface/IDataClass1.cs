using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Data.Interface
{
    public interface IDataClass1
    {
        Task<string> GetUserDetails(HttpContext httpContext);
        void InsertErrorLog(ErrorLogModel errorLogModel, ApplicationDbContext applicationDbContext);
    }
}
