using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace TodoApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ExecuteController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Welcome to the Execute endpoint.";
        }
    }
}