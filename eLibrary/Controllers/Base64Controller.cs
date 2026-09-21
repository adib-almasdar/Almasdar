using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Base64Controller : ControllerBase
    {
        // GET: api/<Base64Controller>
        [HttpGet]
        [Route("Encode")]
        public IActionResult Encode(string text)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(text);
            string base64String = System.Convert.ToBase64String(plainTextBytes);

            return StatusCode(200, new
            {
                base64String = base64String,
            });

        }


        [HttpPost]
        [Route("Decode")]
        public IActionResult Decode([FromBody] RequestBodyJson requestBody)
        {
            byte[] base64EncodedBytes;
            string plainString;
            ResponseBodyJson responseBody = new ResponseBodyJson();

            try
            {
                if (requestBody.values[0].data.text != null)
                {
                    base64EncodedBytes = System.Convert.FromBase64String(requestBody.values[0].data.text);
                    plainString = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

                    responseBody.values = new ValueResponseBodyJson[1];
                    responseBody.values[0] = new ValueResponseBodyJson();
                    responseBody.values[0].data = new DataResponseBodyJson();
                    responseBody.values[0].recordId = requestBody.values[0].recordId;
                    responseBody.values[0].data.decodedText = plainString;
                }
                else
                {
                    base64EncodedBytes = System.Convert.FromBase64String(requestBody.values[0].data.text);
                    plainString = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

                    responseBody.values = new ValueResponseBodyJson[1];
                    responseBody.values[0] = new ValueResponseBodyJson();
                    responseBody.values[0].data = new DataResponseBodyJson();
                    responseBody.values[0].recordId = requestBody.values[0].recordId;
                    responseBody.values[0].data.decodedText = "";
                }

            }
            catch
            {

                responseBody.values = new ValueResponseBodyJson[1];
                responseBody.values[0] = new ValueResponseBodyJson();
                responseBody.values[0].data = new DataResponseBodyJson();
                responseBody.values[0].recordId = requestBody.values[0].recordId;
                responseBody.values[0].data.decodedText = requestBody.values[0].data.text;
            }

            return StatusCode(200, responseBody);

        }


        [HttpGet("GetEnvironementVariable")]
        public IActionResult GetEnvironementVariable()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                  ?? "Development";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: false)
                .Build();
            var env = configuration["Environment"];
            return Ok(configuration["Environment"]);
        }
    }


    public class RequestBodyJson
    {
        public Value[] values { get; set; }
    }

    public class Value
    {
        public string recordId { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string text { get; set; }
    }




    public class ResponseBodyJson
    {
        public ValueResponseBodyJson[] values { get; set; }
    }

    public class ValueResponseBodyJson
    {
        public string recordId { get; set; }
        public DataResponseBodyJson data { get; set; }
        public Error?[] errors { get; set; }
        public Warnings? warnings { get; set; }
    }

    public class DataResponseBodyJson
    {
        public string? decodedText { get; set; }
    }

    public class Warnings
    {
        public string message { get; set; }
    }

    public class Error
    {
        public string message { get; set; }
    }


}
