using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpacePark2;
using SpacePark2.Models;

namespace SpacePark2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpaceTravellersController : ControllerBase
    {
        private readonly SpaceParkContext _context;

        public SpaceTravellersController(SpaceParkContext context)
        {
            _context = context;
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id is null)
                return BadRequest();

            var test = await _context.SpaceTraveller.FindAsync(id);

            if (test is null)
                return BadRequest();

            return Ok(test);
        }

       

        private bool SpaceTravellerExists(string name)
        {
            return _context.SpaceTraveller.Any(e => e.Name == name);
        }
    }
}
