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
        //public async Task<IActionResult> Get(int? id)
        //{
        //    if (id is null)
        //        return BadRequest();

        //    var test = await _context.SpaceTraveller.FindAsync(id);

        //    if (test is null)
        //        return BadRequest();

        //    return Ok(test);
        //}

        // istf att felhantera nullbart, overloada med metod som tar inga parametrar


        [HttpGet("{name}")]
        public IActionResult GetHabitants(string name)
        {
            var h = _repo.GetSpaceTravellerByName(name);
            return Ok(new{Name= h});
        }
       

        private bool SpaceTravellerExists(string name)
        {
            return _context.SpaceTraveller.Any(e => e.Name == name);
        }
    }
}
