using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ndlDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpGet("1")]
        public string Get()
        {
            return "Lớp 02";
        }

        [HttpGet("ndl")]
        public string GetName( string name, int age)
        {
            return name;
        }
            
        [HttpPost]
        public string Post([FromBody]string name)
        {
            return name;
        }

    }
}
