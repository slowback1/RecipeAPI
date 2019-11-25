using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipieAPI.Models;
using Newtonsoft.Json;

namespace RecipieAPI.Controllers
{
    [ApiController]
    [Route("/")]
    public class Root
    { 
        readonly RouteTree r = new RouteTree();
        [HttpGet]
        public string Result()
        {
            string json = JsonConvert.SerializeObject(r);
            return json;
        }
    }
}
