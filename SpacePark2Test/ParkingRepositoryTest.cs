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
        public Task AddParking(Parking parking)
        {
            throw new NotImplementedException();
        }

        public Task<Parking> EndParking(SpaceTraveller traveller)
        {
            throw new NotImplementedException();
        }

        public Task<List<Parking>> History(SpaceTraveller traveller)
        {
            throw new NotImplementedException();
        }
    }
}
