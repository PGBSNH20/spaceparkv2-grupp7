﻿using Microsoft.AspNetCore.Http;
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
        private readonly ISpaceTravellerRepository _travellerRepository;
        private readonly IParkingRepository _parkingRepository;
        

        public ParkingController(ISpaceTravellerRepository travellerRepository, IParkingRepository parkingRepository)
        {
            _travellerRepository = travellerRepository;
            _parkingRepository = parkingRepository;
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

            //TODO metod som validerar parkinghouse och nekar om de ej finns

            var starShips = await swapi.ChooseStarShip(traveller);
            if (!starShips.Contains(shipModel.ToLower()))
                return BadRequest("You don't own this Starship");

            var shipLengt = await swapi.GetShipLength(shipModel);

            var parking = new Parking
            {
                SpaceTraveller = _travellerRepository.CreateSpaceTraveller(await _travellerRepository.Get(name), traveller),
                ParkingHouse = new ParkingHouse { Name = "" },
                StarShip = new StarShip { ShipLength = shipLengt, StarShipModel = shipModel },

            };

            await _parkingRepository.AddParking(parking);
            return Ok();
        }

       

    }

}


