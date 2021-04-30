using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpacePark2.Repositories;

namespace SpacePark2Test
{
    class SpaceTravellerRepoTest : ISpaceTravellerRepo
    {
        public Task<string> GetSpaceTravellerByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
