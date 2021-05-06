using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpacePark2.Filter;
using SpacePark2.Models;
using SpacePark2.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark2.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ParkingHouseController : ControllerBase
    {
        private readonly IParkingHouseRepository _parkingHouseRepository;
        
        [FromHeader(Name = "ApiKey")]
        public string Key { get; set; }

        public ParkingHouseController(IParkingHouseRepository parkingHouseRepository)
        {
            _parkingHouseRepository = parkingHouseRepository;
        }

        //[FromHeader(Name = "AdminApiKey")]
        //public string UserIdentity { get; set; }

        [AdminApiKeyAuth]
        [HttpPost("ParkingHouse")]
        public async Task<IActionResult> Post([FromHeader(Name = "AdminApiKey")][Required] string Header, string name)
        {
            if (name == null)
                return BadRequest("You have to enter a name for the parkinghouse");

            await _parkingHouseRepository.Post(name);
            return Ok();
        }

        [ApiKeyAuth]
        [HttpGet]
        public async Task<IActionResult> Get([FromHeader(Name = "ApiKey")][Required] string Header)
        {
            return Ok(await _parkingHouseRepository.Get());
        }
    }
}
