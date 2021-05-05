using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpacePark2;
using SpacePark2.Models;
using SpacePark2.Repositories;

namespace SpacePark2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpaceTravellersController : ControllerBase
    {
        private readonly ISpaceTravellerRepository _travellerRepository;
        private readonly IParkingRepository _parkingRepository;

        public SpaceTravellersController(ISpaceTravellerRepository travellerRepository, IParkingRepository parkingRepository)
        {
            _travellerRepository = travellerRepository;
            _parkingRepository = parkingRepository;
        }

        [HttpPut("{name}/checkOut")]
        public async Task<IActionResult> Put(string name)
        {
            var spaceTraveller = await _travellerRepository.Get(name);
            if (spaceTraveller == null)
                return BadRequest("You are not parked here!");

            var onGoingParking = await _parkingRepository.EndParking(spaceTraveller);
            if (onGoingParking != null)
                return Ok($"Cost of parking {onGoingParking.Cost}, have a nice day!");

            return BadRequest("You don't have an ongoing parking");
        }


        [HttpGet("{name}/history")]

        public async Task<IActionResult> Get(string name)
        {
            var traveller = await _travellerRepository.Get(name);

            if (traveller is null)
                return BadRequest("You don't have any parking history");

            var history = await _parkingRepository.History(traveller);
            if (history != null)
                return Ok(history);

            return BadRequest("No history found");
        }


    }
}
