using System;
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

            if (name == "Obi-Wan Kenobi")
            {
                return new SpaceTraveller()
                {
                    Id = Guid.NewGuid(),
                    Name = name
                };
            }

            return null;
        }

        public SpaceTraveller ValidateSpaceTraveller(SpaceTraveller existingTraveller, Service.SpaceTraveller newTraveller)
        {
            if (existingTraveller != null)
                return existingTraveller;

            return new SpaceTraveller() {Name = newTraveller.Name};
        }

        public Task<T> Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }
    }
}
