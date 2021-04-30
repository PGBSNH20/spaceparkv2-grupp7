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
        private readonly SpaceParkContext _context;
        private readonly ISpaceTravellerRepo _repo;

        public SpaceTravellersController(SpaceParkContext context, ISpaceTravellerRepo repo)
        {
            _context = context;
            _repo = repo;
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(Guid id)
        //{
        //    if (id == Guid.Empty)
        //        return BadRequest();

        //    var test = await _context.SpaceTraveller.FindAsync(id);

        //    if (test is null)
        //        return BadRequest();

        //    return Ok(test);
        //}

        // istf att felhantera nullbart, overloada med metod som tar inga parametrar
        //[HttpGet]

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var traveller = await _repo.Get(name);

            if (traveller is null)
                return BadRequest();

            return Ok(new{Name= traveller});
        }

        [HttpPost("{SpaceTraveller}")]
        public async Task<IActionResult> Post(SpaceTraveller traveller)
        {
            //finns denna i swappi
            //ja skicka till databasen
            // nej skicka felkod
            await _repo.Post(traveller);
            await _repo.Save();
            return Ok(new {traveller.Name });
        }

        private bool SpaceTravellerExists(string name)
        {
            return _context.SpaceTraveller.Any(e => e.Name == name);
        }
    }
}
