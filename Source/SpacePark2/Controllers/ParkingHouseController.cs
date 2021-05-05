using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpacePark2.Models;
using SpacePark2.Repositories;
using System;
using System.Collections.Generic;
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
        [HttpPost("{ParinkHouse}")]
        public async Task<IActionResult> Post(string name, StarShip starShip)
        {
            
            await _parkingHouseRepository.Post(name);
            return Ok();

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _parkingHouseRepository.Get());
        }
    }
}
