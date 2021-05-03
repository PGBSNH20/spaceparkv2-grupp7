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

        //public async Task<SpaceTraveller> Get(Guid Id)
        //{
        //    return await _context.SpaceTraveller.FirstOrDefaultAsync(x => x.Id == Id);
        //}

        public async Task<SpaceTraveller> Get(string name)
        {
            return await _context.SpaceTraveller.FirstOrDefaultAsync(x => x.Name == name);
        }

        public Task Update(string name)
        {
            throw new NotImplementedException();
        }

        //public async Task<string> GetSpaceTravellerByName(string name)
        //{
        //    // dbcontext tjafs
        //    await Task.Delay(1);
        //    return $"Habitant {name}";
        //}

    }
}
