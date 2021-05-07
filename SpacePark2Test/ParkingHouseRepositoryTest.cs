using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpacePark2.Models;
using SpacePark2.Repositories;

namespace SpacePark2Test
{
    class ParkingHouseRepositoryTest : IParkingHouseRepository
    {
        public async Task AddNewParkingHouseAsync(string name, double capacity)
        {
            await Task.Delay(1);
        }

        public async Task<ParkingHouse> Get(string name)
        {
            await Task.Delay(1);

            if (name == "NabooGalleria")
            {
                return new ParkingHouse()
                {
                    Name = name,
                    Capacity = 987.6
                };

            }
            return null;
        }

        Task<List<ParkingHouseDTO>> IParkingHouseRepository.Get()
        {
            throw new NotImplementedException();
        }
    }
}
