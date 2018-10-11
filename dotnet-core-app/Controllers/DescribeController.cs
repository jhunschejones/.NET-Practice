using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;

namespace TodoApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class DescribeController : ControllerBase
    {
        public class Route 
        {
            public string route { get; set; }
            public string method { get; set; }
            public string description { get; set; }
            public dynamic data { get; set; }
        }

        public class Post
        {
            public string Name { get; set; }
            public bool IsComplete { get; set; } 
        }

        public class Describe
        {
        
            public string endpoint
            {
                get
                {
                    return "dotnet-app";
                }
            }
            public string url 
            { 
                get
                {
                    return "http://dotnet-app:5005";
                }
            }
            public object[] action
            {
                get
                {
                    object[] myAction = new object[10];
                    myAction[0] = new Route
                    { 
                        route = "/describe",
                        method = "GET",
                        description = "Returns this schema. Other apps or interfaces can use this endpoint to retrieve the routes available in this application",
                        data = ""
                    };
                    myAction[1] = new Route
                    { 
                        route = "/execute",
                        method = "GET",
                        description = "Executes a schema",
                        data = ""
                    };
                    myAction[2] = new Route
                    { 
                        route = "/",
                        method = "GET",
                        description = "Returns a single page UI for the to-do list",
                        data = ""
                    };
                    myAction[3] = new Route
                    { 
                        route = "/api",
                        method = "GET",
                        description = "Returns all to-do items",
                        data = ""
                    };
                    Post toDoPost = new Post { Name = "Additional to-do item", IsComplete = false };
                    myAction[4] = new Route
                    { 
                        route = "/api",
                        method = "POST",
                        description = "Create a new to-do item",
                        data = toDoPost
                    };
                    myAction[5] = new Route
                    { 
                        route = "/api/1",
                        method = "GET",
                        description = "Returns a single to-do item with ID 1",
                        data = ""
                    };
                    Post updatePost = new Post { IsComplete = true };
                    myAction[6] = new Route
                    { 
                        route = "/api/1",
                        method = "PUT",
                        description = "Update a single to-do item with ID 1",
                        data = updatePost
                    };
                    myAction[7] = new Route
                    { 
                        route = "/api/1",
                        method = "DELETE",
                        description = "Delete a single to-do item with ID 1",
                        data = ""
                    };
                    myAction[8] = new Route
                    { 
                        route = "/api/weather/portland",
                        method = "GET",
                        description = "Call an external API to return basic weather JSON data about Portland",
                        data = ""
                    };
                    myAction[9] = new Route
                    { 
                        route = "/api/weather/dublin",
                        method = "GET",
                        description = "Call an external API to return basic weather JSON data about Dublin",
                        data = ""
                    };

                    return myAction;
                }
            }
        }

        [HttpGet]
        public ActionResult Get()
        {
            Describe describe = new Describe();
            JsonConvert.SerializeObject(describe);
            return Ok(describe);
        }
    }
}