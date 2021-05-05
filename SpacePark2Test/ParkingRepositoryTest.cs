using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpacePark2.Models;
using SpacePark2.Repositories;

namespace SpacePark2Test
{
    class ParkingRepositoryTest : IParkingRepository
    {
        public async Task AddParking(Parking parking)
        {
            await Task.Delay(1);
        }

        public Task<bool> CheckCapacity(double shipLength, ParkingHouse parkingHouse)
        {
            throw new NotImplementedException();
        }

        public bool CheckIfParked(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Parking> EndParking(SpaceTraveller traveller)
        {
            if (traveller.Name == "Obi-Wan Kenobi")
            {
                var obiPark = new Parking()
                {
                    SpaceTraveller = traveller,
                    ArrivalTime = Convert.ToDateTime("2021 - 05 - 05 14:43"),
                    DepartureTime = Convert.ToDateTime("2021 - 05 - 06 01:12")
                };
                DateTime start = (DateTime) obiPark.DepartureTime;
                DateTime end = obiPark.ArrivalTime;
                obiPark.Cost = (int)(Math.Round(((end - start).TotalMinutes),0) * 250);

                return obiPark;
            }

            return null;
        }

        public Task<List<Parking>> History(SpaceTraveller traveller)
        {
            throw new NotImplementedException();
        }
    }
}
