using System;
using System.Web; 
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;

namespace TodoApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ExecuteController : ControllerBase
    {
        [HttpPost]
        public string Post([FromBody] string content)
        {
            return content;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Welcome to the Execute endpoint.";
        }
    }
}