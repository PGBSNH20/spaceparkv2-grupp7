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
        [FromHeader(Name = "ApiKey")][Required]
        public string Key { get; set; }

        public ParkingController(ISpaceTravellerRepository travellerRepository, IParkingRepository parkingRepository, IParkingHouseRepository parkingHouseRepository, ISwApi swApi)
        {
            _travellerRepository = travellerRepository;
            _parkingRepository = parkingRepository;
            _parkingHouseRepository = parkingHouseRepository;
            _swApi = swApi;
        }

        /// <summary>
        /// Enter your information to park your starship
        /// </summary>
        /// <param name = "travellerName">Space Traveller</param>
        /// <param name="parkingHouse">Parking House</param>
        /// <param name="shipModel">Starship Model</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([Required(ErrorMessage = "Invalid input")] String parkingHouse, [Required][StringLength(21)] string travellerName, [Required] string shipModel)
        {
            var selectedParkingHouse = await _parkingHouseRepository.Get(parkingHouse);
            if (selectedParkingHouse is null)
                return BadRequest("This Parking house does not exist");

            if (await _parkingRepository.IsParkedAsync(await _travellerRepository.Get(travellerName)))
                return Conflict("You're already parked, go find your spaceship!");

            var traveller = await _swApi.GetSpaceTravellerAsync(travellerName);
            if (traveller is null)
                return NotFound($"{travellerName} is not famous and can´t access this spacepark");

            var starShips = await _swApi.ChooseStarShipAsync(traveller);
            if (!starShips.Contains(shipModel.ToLower()))
                return BadRequest("You don't own this Starship");

            var shipLength = await _swApi.GetShipLengthAsync(shipModel);

            if(!_parkingRepository.ParkShipAsync(shipLength, selectedParkingHouse).Result)
                return BadRequest("There is no room in this parking structure");
            
            var parking = new Parking
            {
                SpaceTraveller = _travellerRepository.ValidateSpaceTraveller(await _travellerRepository.Get(travellerName), traveller),
                ParkingHouse = selectedParkingHouse,
                StarShip = new StarShip { ShipLength = shipLength, StarShipModel = shipModel },
            };

            await _parkingRepository.AddParkingAsync(parking);

            return Ok($"You parked your car at {DateTime.Now}!");
        }
    }
}


