using SpacePark2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark2.Repositories
{
    public class StarShipRepo : Repository, IStarShipRepo
    {
        public StarShipRepo(SpaceParkContext context) : base(context) { }

        public async Task Post(StarShip starShip)
        {
            await _context.AddAsync(starShip);
        }
    }
}
