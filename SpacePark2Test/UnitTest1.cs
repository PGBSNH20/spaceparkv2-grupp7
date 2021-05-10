using System;
using Microsoft.AspNetCore.Mvc;
using Service.Repository.Contracts;
using Xunit;
using SpacePark2.Controllers;
using SpacePark2.Repositories;

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
            var result = await controller.Post( "NabooGalleria", "Obi-Wan Kenobi", "Jedi starfighter");

            Assert.Equal($"You parked your car at {DateTime.Now}!", ((OkObjectResult)result).Value.ToString());
        }

        [Fact]
        public async void PostParking_WrongTravellerName_ExpectBadRequest()
        {
            var controller = new ParkingController(spaceTravellerRepository, parkingRepository, parkingHouseRepository, swApi);

            // Test
            var result = await controller.Post( "NabooGalleria", "Chewie", "Jedi starfighter");

            Assert.Equal("Chewie is not famous and can´t access this spacepark", ((NotFoundObjectResult)result).Value.ToString());
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
            var result = await controller.Post( "NabooGalleria", "Obi-Wan Kenobi", "Trade Federation cruiser");

            Assert.Equal("There is no room in this parking structure", ((BadRequestObjectResult)result).Value.ToString());
        }

        // Parking House
        [Fact]
        public async void PostParkingHouse_AllValuesValid_ExpectOK()
        {
            var controller = new ParkingHouseController(parkingHouseRepository);

            // Test
            var result = await controller.Post("Naboo Galleria", 6000, "Header");

            Assert.Equal("Naboo Galleria has been added with a capacity of 6000 total meters parking!", ((OkObjectResult)result).Value.ToString());
        }

        // Spacetraveller
        [Fact]
        public async void CheckoutSpaceTraveller_ExistingName_ExpectCostReturn()
        {
            var controller = new SpaceTravellersController(spaceTravellerRepository, parkingRepository);
            // Test
            var result = await controller.Put("Obi-Wan Kenobi");

            Assert.Equal("Cost of parking 157250, have a nice day!", ((OkObjectResult)result).Value.ToString());
        }

        [Fact]
        public async void CheckoutSpaceTraveller_BadName_ExpectException()
        {
            var controller = new SpaceTravellersController(spaceTravellerRepository, parkingRepository);
            // Test
            var result = await controller.Put("Chewie");

            Assert.Equal("You are not parked here!", ((BadRequestObjectResult)result).Value.ToString());
        }

        [Fact]
        public async void GetSpaceTraveller_ExistingName_ExpectCostReturn()
        {
            var controller = new SpaceTravellersController(spaceTravellerRepository, parkingRepository);
            // Test
            var result = await controller.Put("Obi-Wan Kenobi");

            Assert.Equal("Cost of parking 157250, have a nice day!", ((OkObjectResult)result).Value.ToString());
        }

        [Fact]
        public async void GetSpaceTravellersParkingHistory_ExistingTravellerName_Expect_NotNull()
        {
            var controller = new SpaceTravellersController(spaceTravellerRepository, parkingRepository);
            var result = await controller.Get("Obi-Wan Kenobi");
            Assert.NotNull((OkObjectResult)result);

        }

        [Fact]
        public async void GetSpaceTravellersParkingHistory_WrongTravellerName_ExpectException()
        {
            var controller = new SpaceTravellersController(spaceTravellerRepository, parkingRepository);
            // Test
            var result = await controller.Get("Harry");

            Assert.Equal("You don't have any parking history", ((BadRequestObjectResult)result).Value.ToString());
        }
    }
}
