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


        // Parking
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

        // Parking House
        [Fact]
        public async void PostParkingHouse_AllValuesValid_ExpectAOK()
        {
            var controller = new ParkingHouseController(parkingHouseRepository);

            // Test
            var result = await controller.Post("Header", "Naboo Galleria", 6000);

            Assert.Equal("Naboo Galleria has been added with a capacity of 6000 total meters parking!", ((OkObjectResult)result).Value.ToString());
        }

        // Spacetraveller
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

        //public async Task<IActionResult> Put([StringLength(16)] string name)
        //{
        //    var spaceTraveller = await _travellerRepository.Get(name);
        //    if (spaceTraveller is null)
        //        return BadRequest("You are not parked here!");

        //    var onGoingParking = await _parkingRepository.EndParkingAsync(spaceTraveller);
        //    if (onGoingParking != null)
        //        return Ok($"Cost of parking {onGoingParking.Cost}, have a nice day!");

        //    return BadRequest("You don't have an ongoing parking");
        //}

    }
}
