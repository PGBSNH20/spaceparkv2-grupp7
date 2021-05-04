using SpacePark2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark2.Repositories
{
    public class ParkingRepository : Repository, IParkingRepository
    {
        public ParkingRepository(SpaceParkContext context) : base(context) { }


        public async Task AddParking(Parking parking)
        {
            await Add(parking);
        }


    }
}
