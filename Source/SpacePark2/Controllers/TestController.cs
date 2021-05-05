using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpacePark2.Filter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark2.Controllers
{
    [ApiKeyAuth]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [FromHeader(Name = "ApiKey")]
        public string UserIdentity { get; set; }
        //[FromHeader(Name ="ApiKey")][Required] string Header
        [HttpGet("secret")]
        public IActionResult Get()
        {
            return Ok("This works");
        }
    }
}
