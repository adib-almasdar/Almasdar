using CommonLib.Services.Interface;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace CommonLib.Services
{
    public class HTTPRequestService: IHTTPRequestService
    {
        public string ExecuteRestAPI(string query, string rawAPIUrl,string methodType,string header,string headerValue)
        {
            try
            {
                var client = new RestClient(rawAPIUrl + query);

                if (methodType == "Post")
                {
                    var request = new RestRequest("", Method.Post);
                    request.Timeout = Timeout.InfiniteTimeSpan;
                    request.AddHeader(header, headerValue);
                    RestResponse response = client.Execute(request);
                    if (response.Content != null)
                    {
                        return response.Content;
                    }
                    else
                    {
                        return "";
                    }
                }
                else if(methodType == "Get")
                {
                    var request = new RestRequest("", Method.Get);
                    request.Timeout = Timeout.InfiniteTimeSpan;
                    request.AddHeader(header, headerValue);
                    RestResponse response = client.Execute(request);
                    if (response.Content != null)
                    {
                        return response.Content;
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }


            }
            catch (Exception exc)
            {
                return "";
            }
        }
    }
}
