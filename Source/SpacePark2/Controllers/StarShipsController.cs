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
    public class StarShipsController : ControllerBase
    {
        private readonly SpaceParkContext _context;
        private readonly IStarShipRepo _repo;

        public StarShipsController(SpaceParkContext context, IStarShipRepo repo)
        {
            _context = context;
            _repo = repo;
        }

        [HttpPost("{StarShip}")]
        public async Task<IActionResult> Post(StarShip starShip)
        {
            await _repo.Post(starShip);
            await _repo.Save();
            return Ok(new { Name = starShip.StarShipModel });
        }

    }
}
