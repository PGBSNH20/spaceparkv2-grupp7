//using System;
//using Microsoft.AspNetCore.Mvc;
//using Service;
//using Service.Repository.Contracts;
//using Xunit;
//using SpacePark2;
//using SpacePark2.Controllers;
//using SpacePark2.Repositories;

//namespace SpacePark2Test
//{
//    public class UnitTest1
//    {
//        // Test setup
//        // Setup
//        ISwApi swApi = new SwApiTest();
//        ISpaceTravellerRepository spaceTravellerRepository = new SpaceTravellerRepositoryTest();
//        IParkingRepository parkingRepository = new ParkingRepositoryTest();

        


//        /* Metod jag vill testa:
//         public async Task<IActionResult> Post(string travellerName, string parkingHouse, string shipModel)
//        {
            

//            var traveller = await swapi.GetSpaceTraveller(travellerName);
//            if (traveller == null)
//                return BadRequest("You have entered an invalid input");

//            //TODO metod som validerar parkinghouse och nekar om de ej finns
//            // kollar om det

//            var starShips = await swapi.ChooseStarShip(traveller);
//            if (!starShips.Contains(shipModel.ToLower()))
//                return BadRequest("You don't own this Starship");

//            var shipLength = await swapi.GetShipLength(shipModel);
             
//            var parking = new Parking
//            {
//                SpaceTraveller = _travellerRepository.CreateSpaceTraveller(await _travellerRepository.Get(travellerName), traveller),
//                ParkingHouse = new ParkingHouse { Name = ""},
//                StarShip = new StarShip { ShipLength = shipLength, StarShipModel = shipModel },
//            };

//            await _parkingRepository.AddParking(parking);
//            return Ok();
//        }*/
//        [Fact]
//        public async void PostParking_AllValuesValid_ExpectAOK()
//        {
            
//            var controller = new ParkingController(spaceTravellerRepository, parkingRepository, swApi);


//            // Test
//            var result = await controller.Post("Obi-Wan Kenobi", "SpacePark", "Milennium Falcon");

//            Assert.IsAssignableFrom<OkObjectResult>(result);

//            // om vi returnerar Ok(någonting)
//            //var r = ((OkObjectResult) result).Value;

//        }

//        [Fact]
//        public void GetPerson()
//        {
//            ISpaceTravellerRepository TestRepository = new SpaceTravellerRepositoryTest();
//            var result = TestRepository.Get("Sam");
//            Assert.NotNull((result.Id).ToString());
//        }
//    }
//}
