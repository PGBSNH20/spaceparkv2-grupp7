using SpacePark2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark2.Repositories
{
    public class ParkingRepo : Repository, IParkingRepo
    {
        public ParkingRepo(SpaceParkContext context) : base(context) { }


        public async Task AddParking(Parking parking)
        {
            _context.Add(parking);
            await Save();
        }


    }
}
