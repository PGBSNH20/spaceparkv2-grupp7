using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpacePark2.Models;

namespace SpacePark2.Repositories
{
    public class SpaceTravellerRepo : Repository, ISpaceTravellerRepo
    {
        public SpaceTravellerRepo(SpaceParkContext context): base(context) { }

        public async Task<SpaceTraveller> Get(Guid Id)
        {
            return await _context.SpaceTraveller.FirstOrDefaultAsync(x => x.Id == Id);
        }
       
        public async Task<string> GetSpaceTravellerByName(string name)
        {
            // dbcontext tjafs
            await Task.Delay(1);
            return $"Habitant {name}";
        }

    }
}
