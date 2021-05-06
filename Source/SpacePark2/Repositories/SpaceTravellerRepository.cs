using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpacePark2.Models;

namespace SpacePark2.Repositories
{
    public class SpaceTravellerRepository : Repository, ISpaceTravellerRepository
    {
        public SpaceTravellerRepository(SpaceParkContext context) : base(context) { }

        public SpaceTraveller ValidateSpaceTraveller(SpaceTraveller existingTraveller, Service.SpaceTraveller newTraveller)
        {
            if (existingTraveller != null)
                return existingTraveller;

            return new SpaceTraveller { Name = newTraveller.Name };
        }
        public async Task<SpaceTraveller> Get(string name)
        {
            return await _context.SpaceTraveller.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
