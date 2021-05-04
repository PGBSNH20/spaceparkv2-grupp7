using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpacePark2.Models;
using SpacePark2.Repositories;

namespace SpacePark2Test
{
    class SpaceTravellerRepositoryTest : ISpaceTravellerRepository
    {
        public async Task<SpaceTraveller> Get(Guid id)
        {
            await Task.Delay(1);

            return new SpaceTraveller() { Id = id, Name = "Chewbacca" };
        }

        public async Task<SpaceTraveller> Get(string name)
        {
            await Task.Delay(1); 

            return new SpaceTraveller()
            {
                Id = Guid.NewGuid(),
                Name = name
            };
        }

        public Task<Parking> EndParking(SpaceTraveller traveller)
        {
            throw new NotImplementedException();
        }

        public SpaceTraveller CreateSpaceTraveller(SpaceTraveller existingTraveller, Service.SpaceTraveller newTraveller)
        {
            // använd SpaceTraveller i SpacePark2
            throw new NotImplementedException();
        }

        public Task<T> Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task Update<T>(T[] entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }
    }
}
