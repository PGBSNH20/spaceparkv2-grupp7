using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpacePark2.Models;
using SpacePark2.Repositories;

namespace SpacePark2Test
{
    class ParkingRepositoryTest : IParkingRepository
    {
        public Task AddNewParking(ParkingHouse parkingHouse, SpaceTraveller traveller, StarShip starShip)
        {
            throw new NotImplementedException();
        }

        public Task AddParking(Parking parking)
        {
            throw new NotImplementedException();
        }
    }
}
