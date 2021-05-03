using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpacePark2.Models;
using SpacePark2.Repositories;

namespace SpacePark2Test
{
    class SpaceTravellerRepoTest : ISpaceTravellerRepo
    {

        public Task<T> Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<SpaceTraveller> Get(Guid id)
        {

            throw new NotImplementedException();
        }

        public async Task<SpaceTraveller> Get(string name)
        {
            await Task.Delay(1); 

            return new SpaceTraveller()
            {
                Id = Guid.NewGuid(),
                Name = "Sam"
            };

        }

        public Task<string> GetSpaceTravellerByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task Post(SpaceTraveller traveller)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public Task Update(string name)
        {
            throw new NotImplementedException();
        }
    }
}
