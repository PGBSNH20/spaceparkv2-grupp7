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
        public ParkingHouseController(IParkingHouseRepository parkingHouseRepository)
        {
            _parkingHouseRepository = parkingHouseRepository;
        }

        [AdminApiKeyAuth]
        [HttpPost("ParkingHouse")]
        public async Task<IActionResult> Post([FromHeader(Name = "AdminApiKey")][Required] string Header, [Required(ErrorMessage = "Invalid format for parking house")][MinLength(2)]string name, [Required][Range(500,500000)]double capacity)
        {
            await _parkingHouseRepository.AddNewParkingHouseAsync(name, capacity);
            return Ok($"{name} has been added with a capacity of {capacity} total meters parking!");
        }

        [ApiKeyAuth]
        [HttpGet]
        public async Task<IActionResult> Get([FromHeader(Name = "ApiKey")][Required] string Header)
        {
            return Ok(await _parkingHouseRepository.Get());
        }
    }
}
