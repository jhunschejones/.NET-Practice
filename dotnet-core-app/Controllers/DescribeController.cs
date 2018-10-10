using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace TodoApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class DescribeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Welcome to the Describe endpoint.";
        }
    }
}