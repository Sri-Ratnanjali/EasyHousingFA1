using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EasyHousingFA1
{
    public class EasyHousing
    {
        public string Region { get; set; }
        public int Price { get; set; }
    }
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            EasyHousing es = new EasyHousing
            {
                Price = int.Parse(Environment.GetEnvironmentVariable("Price")),
                Region = Environment.GetEnvironmentVariable("Region")

            };
            string jsonString = System.Text.Json.JsonSerializer.Serialize(es);
            return new OkObjectResult(jsonString);
        }
    }
}
