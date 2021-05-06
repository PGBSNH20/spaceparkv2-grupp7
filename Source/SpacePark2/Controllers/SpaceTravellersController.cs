using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpacePark2;
using SpacePark2.Filter;
using SpacePark2.Models;
using SpacePark2.Repositories;

namespace SpacePark2.Controllers
{
    [ApiKeyAuth]
    [Route("api/[controller]")]
    [ApiController]
    public class SpaceTravellersController : ControllerBase
    {
        private readonly ISpaceTravellerRepository _travellerRepository;
        private readonly IParkingRepository _parkingRepository;
        
        [FromHeader(Name = "ApiKey")]
        public string Key { get; set; }
        public SpaceTravellersController(ISpaceTravellerRepository travellerRepository, IParkingRepository parkingRepository)
        {
            _travellerRepository = travellerRepository;
            _parkingRepository = parkingRepository;
        }

        /// <summary>
        /// Unpark your spaceship and pay
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPut("{name}/checkOut")]
        public async Task<IActionResult> Put([StringLength(21)]string name)
        {
            var spaceTraveller = await _travellerRepository.Get(name);
            if (spaceTraveller is null)
                return BadRequest("You are not parked here!");

            var onGoingParking = await _parkingRepository.EndParkingAsync(spaceTraveller);
            if (onGoingParking != null)
                return Ok($"Cost of parking {onGoingParking.Cost}, have a nice day!");

            return BadRequest("You don't have an ongoing parking");
        }

        /// <summary>
        /// Get information on all previous parkings
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}/history")]

        public async Task<IActionResult> Get([StringLength(21)] string name)
        {
            var traveller = await _travellerRepository.Get(name);

            if (traveller is null)
                return BadRequest("You don't have any parking history");

            var history = await _parkingRepository.ArchiveParkingAsync(name);
            if (history != null)
                return Ok(history);

            return BadRequest("No history found");
        }
    }
}
