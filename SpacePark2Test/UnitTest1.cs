using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Repository.Contracts;
using Xunit;
using SpacePark2;
using SpacePark2.Controllers;
using SpacePark2.Repositories;
using Xunit.Sdk;

namespace SpacePark2Test
{
    public class UnitTest1
    {
        // Test setup
        // Setup
        ISwApi swApi = new SwApiTest();
        ISpaceTravellerRepository spaceTravellerRepository = new SpaceTravellerRepositoryTest();
        IParkingRepository parkingRepository = new ParkingRepositoryTest();
        IParkingHouseRepository parkingHouseRepository = new ParkingHouseRepositoryTest();

        [Fact]
        public async void PostParking_AllValuesValid_ExpectAOK()
        {
            var controller = new ParkingController(spaceTravellerRepository, parkingRepository, parkingHouseRepository, swApi);

            // Test
            var result = await controller.Post("Obi-Wan Kenobi", "NabooGalleria", "Jedi starfighter");

            Assert.Equal("You're parked!", ((OkObjectResult)result).Value.ToString());
        }

        [Fact]
        public async void PostParking_BadName_ExpectBadRequest()
        {
            var controller = new ParkingController(spaceTravellerRepository, parkingRepository, parkingHouseRepository, swApi);

            // Test
            var result = await controller.Post("Chewie", "NabooGalleria", "Jedi starfighter");

            Assert.Equal("You have entered an invalid input", ((BadRequestObjectResult)result).Value.ToString());
        }

        [Fact]
        public async void PostParking_BadParkingHouse_ExpectBadRequest()
        {
            var controller = new ParkingController(spaceTravellerRepository, parkingRepository, parkingHouseRepository, swApi);

            // Test
            var result = await controller.Post("Obi-Wan Kenobi", "Space Park", "Jedi starfighter");

            Assert.Equal("This Parking house does not exist", ((BadRequestObjectResult)result).Value.ToString());
        }

        [Fact]
        public async void PostParking_TooLongShip_ExpectBadRequest()
        {
            var controller = new ParkingController(spaceTravellerRepository, parkingRepository, parkingHouseRepository, swApi);

            // Test
            var result = await controller.Post("Obi-Wan Kenobi", "NabooGalleria", "Trade Federation cruiser");

            Assert.Equal("There is no room in this parking structure", ((BadRequestObjectResult)result).Value.ToString());
        }

        /* Test jag vill testa // TODO Uppdatera för att kunna testa
         [HttpPut("checkOut")]
        public async Task<IActionResult> Put(string name)
        {
            var spaceTraveller = await _travellerRepository.Get(name);
            if (spaceTraveller == null)
                return BadRequest("You are not parked here!");

            var onGoingParking = await _parkingRepository.EndParking(spaceTraveller);
            if (onGoingParking != null)
                return Ok($"Cost of parking {onGoingParking.Cost}, have a nice day!");

            return BadRequest("You don't have an ongoing parking");
        }*/

        [Fact]
        public async void PutSpaceTraveller_ExistingName_ExpectCostReturn()
        {
            var controller = new SpaceTravellersController(spaceTravellerRepository, parkingRepository);
            // Test
            var result = await controller.Put("Obi-Wan Kenobi");

            //Assert.Equal("You have entered an invalid input", ((BadRequestObjectResult)result).Value.ToString());
        }

        [Fact]
        public async void PutSpaceTraveller_BadName_ExpectException()
        {
            var controller = new ParkingController(spaceTravellerRepository, parkingRepository, parkingHouseRepository, swApi);

            // Test
            //var result = await controller.Post("Chewie", "SpacePark", "Jedi starfighter");

            //Assert.Equal("You have entered an invalid input", ((BadRequestObjectResult)result).Value.ToString());
        }



        /*[HttpGet("{name}/history")]

        public async Task<IActionResult> Get(string name)
        {
            var traveller = await _travellerRepository.Get(name);

            if (traveller is null)
                return BadRequest("You don't have any parking history");

            var history = await _parkingRepository.History(traveller);
            if (history != null)
                return Ok(history);

            return BadRequest("No history found");
        }*/
    }
}
