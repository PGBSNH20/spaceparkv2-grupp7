using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark2.Repositories
{
    public class SpaceParkRepo : ISpaceParkRepo
    {
        private readonly SpaceParkContext _context;

        public SpaceParkRepo(SpaceParkContext context)
        {
            _context = context;
        }


        public async Task<string> GetHabitantByName(string name)
        {
            // dbcontext tjafs
            await Task.Delay(1);
            return $"Habitant {name}";
        }
    }
}
