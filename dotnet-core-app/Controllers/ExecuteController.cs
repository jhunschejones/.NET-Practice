using System;
using System.Web; 
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace TodoApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ExecuteController : ControllerBase
    {
        [HttpPost]
        public string Post([FromBody] string content)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            client.BaseAddress = new Uri("localhost::5005");

            StringBuilder responseBuilder = new StringBuilder();

            dynamic json = JsonConvert.DeserializeObject(content);

            foreach (var route in json.action)
            {
                // get the http method
                request.Method = json.action.method;
                // get the route
                request.RequestUri = json.action.route;
                // TODO make a request and store the response
                // using `SendAsync` becasue HttpRequestMesasage lets you set the method and uri
                dynamic routeResponse = client.SendAsync(request);

                // adding response 
                responseBuilder.Append(routeResponse);
            }
            return responseBuilder.ToString();
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Welcome to the Execute endpoint.";
        }
    }
}