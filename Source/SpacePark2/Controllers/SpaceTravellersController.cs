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

        public SpaceTravellersController(ISpaceTravellerRepository repo)
        {
            _travellerRepository = repo;
        }

        [HttpPut("checkOut")]
        public async Task<IActionResult> Put(string name)
        {
            var hej = await _travellerRepository.Get(name);
            if (hej == null)
                return BadRequest("You are not parked here!");

            var nästa = await _travellerRepository.EndParking(hej);
            if (nästa == null)
                return BadRequest("You don't have an ongoing parking");

            return Ok($"Cost of parking {nästa.Cost}, have a nice day!");
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var traveller = await _travellerRepository.Get(name);

            if (traveller is null)
                return BadRequest();

            return Ok(new { Name = traveller });
        }

        //[HttpPost("{SpaceTraveller}")]
        //public async Task<IActionResult> Post(SpaceTraveller traveller)
        //{
        //    //finns denna i swappi
        //    //ja skicka till databasen
        //    // nej skicka felkod
        //    await _repo.Post(traveller);
        //    await _repo.Save();
        //    return Ok(new {traveller.Name });
        //}

      
    }
}
