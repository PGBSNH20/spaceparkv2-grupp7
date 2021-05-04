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
        /// <param name="name"></param>
        /// <param name="parkingHouse"></param>
        /// <param name="shipModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(string name, string parkingHouse, string shipModel)
        {
            var swapi = new SwApi();

            var traveller = await swapi.GetSpaceTraveller(name);
            if (traveller == null)
                return BadRequest("You have entered an invalid input");

            // kolla om personen finns, returnera guid/ namn
            var existingTraveller = await _travellerRepo.Get(name);

            var newTraveller = new Models.SpaceTraveller { Name = traveller.Name };

            var ship = await swapi.ChooseStarShip(traveller);
            if (!ship.Contains(shipModel.ToLower()))
                return BadRequest("You don't own this Starship");

            var shipLengt = await swapi.GetShipLength(shipModel);

            Parking parking;
            if (existingTraveller != null)
            {
                parking = new Parking
                {
                    SpaceTraveller = existingTraveller,
                    ParkingHouse = new ParkingHouse { Name = "" },
                    StarShip = new StarShip { ShipLength = shipLengt, StarShipModel = shipModel },

                };

            }
            else
            {
                parking = new Parking
                {
                    SpaceTraveller = newTraveller,
                    ParkingHouse = new ParkingHouse { Name = "" },
                    StarShip = new StarShip { ShipLength = shipLengt, StarShipModel = shipModel },

                };
            }

           // await _parkingRepo.AddParking(parking);
            return Ok();

        }
    }
}
