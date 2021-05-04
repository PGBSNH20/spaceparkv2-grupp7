using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
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
    public class ParkingController : ControllerBase
    {
        private readonly ISpaceTravellerRepo _travellerRepo;
        private readonly IParkingRepo _parkingRepo;
        

        public ParkingController(ISpaceTravellerRepo travellerRepo, IParkingRepo parkingRepo)
        {
            _travellerRepo = travellerRepo;
            _parkingRepo = parkingRepo;
        }

        /// <summary>
        /// Creates a parkingspace.
        /// </summary>
        /// <param name = "name">Space Traveller</param>
        /// <param name="parkingHouse">Parking House</param>
        /// <param name="shipModel">Starship Model</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(string name, string parkingHouse, string shipModel)
        {
            var swapi = new SwApi();

            var traveller = await swapi.GetSpaceTraveller(name);
            if (traveller == null)
                return BadRequest("You have entered an invalid input");

         

            var starShips = await swapi.ChooseStarShip(traveller);
            if (!starShips.Contains(shipModel.ToLower()))
                return BadRequest("You don't own this Starship");

            var shipLengt = await swapi.GetShipLength(shipModel);

            var parking = new Parking
            {
                SpaceTraveller = _travellerRepo.CreateSpaceTraveller(await _travellerRepo.Get(name), traveller),
                ParkingHouse = new ParkingHouse { Name = "" },
                StarShip = new StarShip { ShipLength = shipLengt, StarShipModel = shipModel },

            };

            await _parkingRepo.AddParking(parking);
            return Ok();
        }

       

    }

}


