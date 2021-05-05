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

        [Fact]
        public async void PostParking_AllValuesValid_ExpectAOK()
        {
            var controller = new ParkingController(spaceTravellerRepository, parkingRepository, swApi);

            // Test
            var result = await controller.Post("Obi-Wan Kenobi", "SpacePark", "Jedi starfighter");

            Assert.IsAssignableFrom<OkResult>(result);

            // om vi returnerar Ok(någonting)
            //var r = ((OkResult) result).Value;

        }

        [Fact]
        public async void PostParking_BadName_ExpectBadRequest()
        {
            var controller = new ParkingController(spaceTravellerRepository, parkingRepository, swApi);

            // Test
            var result = await controller.Post("Chewie", "SpacePark", "Jedi starfighter");

            Assert.Equal("You have entered an invalid input", ((BadRequestObjectResult)result).Value.ToString());
        }
    }
}
