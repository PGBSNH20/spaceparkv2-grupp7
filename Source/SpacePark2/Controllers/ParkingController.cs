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
using System.ComponentModel.DataAnnotations;
using SpacePark2.Filter;

namespace SpacePark2.Controllers
{
    [ApiKeyAuth]
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        private readonly ISpaceTravellerRepository _travellerRepository;
        private readonly IParkingRepository _parkingRepository;
        private readonly IParkingHouseRepository _parkingHouseRepository;
        private readonly ISwApi _swApi;
        [FromHeader(Name = "ApiKey")]
        public string Key { get; set; }

        public ParkingController(ISpaceTravellerRepository travellerRepository, IParkingRepository parkingRepository, IParkingHouseRepository parkingHouseRepository, ISwApi swApi)
        {
            _travellerRepository = travellerRepository;
            _parkingRepository = parkingRepository;
            _parkingHouseRepository = parkingHouseRepository;
            _swApi = swApi;
        }

        /// <summary>
        /// Enter your information to park your spaceship
        /// </summary>
        /// <param name = "travellerName">Space Traveller</param>
        /// <param name="parkingHouse">Parking House</param>
        /// <param name="shipModel">Starship Model</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([Required(ErrorMessage = "Invalid input")][StringLength(16, ErrorMessage ="Input is too long")] string travellerName, string parkingHouse, string shipModel)
        {
            var selectedParkingHouse = await _parkingHouseRepository.Get(parkingHouse);
            if (selectedParkingHouse is null)
                return BadRequest("This Parking house does not exist");

            var traveller = await _swApi.GetSpaceTravellerAsync(travellerName);
            if (traveller is null)
                return BadRequest("You have entered an invalid input");

            var starShips = await _swApi.ChooseStarShipAsync(traveller);
            if (!starShips.Contains(shipModel.ToLower()))
                return BadRequest("You don't own this Starship");

            var shipLength = await _swApi.GetShipLengthAsync(shipModel);

            if (await _parkingRepository.CheckIfParkedAsync(await _travellerRepository.Get(travellerName)))
                return BadRequest("You're already parked, go find your spaceship!");

            if(!_parkingRepository.ParkShipAsync(shipLength, selectedParkingHouse).Result)
                return BadRequest("There is no room in this parking structure");
            
            var parking = new Parking
            {
                SpaceTraveller = _travellerRepository.CreateSpaceTraveller(await _travellerRepository.Get(travellerName), traveller),
                ParkingHouse = selectedParkingHouse,
                StarShip = new StarShip { ShipLength = shipLength, StarShipModel = shipModel },
            };

            await _parkingRepository.AddParkingAsync(parking);
            return Ok("You're parked!");
        }
    }
}


