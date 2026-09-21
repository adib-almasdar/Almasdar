using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Services.Interface
{
    public interface IHTTPRequestService
    {
        string ExecuteRestAPI(string query, string rawAPIUrl, string methodType, string header, string headerValue);
    }
}
