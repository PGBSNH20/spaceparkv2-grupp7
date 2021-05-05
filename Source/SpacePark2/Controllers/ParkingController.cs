using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using SpacePark2.Models;
using SpacePark2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.Repository.Contracts;

namespace SpacePark2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        private readonly ISpaceTravellerRepository _travellerRepository;
        private readonly IParkingRepository _parkingRepository;
        private readonly IParkingHouseRepository _parkingHouseRepository;
        private readonly ISwApi _swApi;


        public ParkingController(ISpaceTravellerRepository travellerRepository, IParkingRepository parkingRepository, IParkingHouseRepository parkingHouseRepository, ISwApi swApi)
        {
            _travellerRepository = travellerRepository;
            _parkingRepository = parkingRepository;
            _parkingHouseRepository = parkingHouseRepository;
            _swApi = swApi;
        }

        /// <summary>
        /// Creates a parkingspace.
        /// </summary>
        /// <param name = "travellerName">Space Traveller</param>
        /// <param name="parkingHouse">Parking House</param>
        /// <param name="shipModel">Starship Model</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(string travellerName, string parkingHouse, string shipModel)
        {
            var traveller = await _swApi.GetSpaceTraveller(travellerName);
            if (traveller == null)
                return BadRequest("You have entered an invalid input");

            //TODO metod som validerar parkinghouse och nekar om de ej finns
            // kollar om det
            var selectedParkingHouse = await _parkingHouseRepository.Get(parkingHouse);
            var starShips = await _swApi.ChooseStarShip(traveller);
            if (!starShips.Contains(shipModel.ToLower()))
                return BadRequest("You don't own this Starship");

            var shipLength = await _swApi.GetShipLength(shipModel);

            if (await _parkingRepository.CheckIfParked(await _travellerRepository.Get(travellerName)))
                return BadRequest("You're already parked, go find your spaceship!");

            if(!_parkingRepository.CheckCapacity(shipLength, selectedParkingHouse).Result)
                return BadRequest("There is no room in this parking structure");
            
            var parking = new Parking
            {
                SpaceTraveller = _travellerRepository.CreateSpaceTraveller(await _travellerRepository.Get(travellerName), traveller),
                ParkingHouse = selectedParkingHouse,
                StarShip = new StarShip { ShipLength = shipLength, StarShipModel = shipModel },
            };

            await _parkingRepository.AddParking(parking);
            return Ok("You're parked!");
        }
    }
}


