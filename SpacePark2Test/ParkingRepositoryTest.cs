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
        public async Task AddParkingAsync(Parking parking)
        {
            await Task.Delay(1);
        }

        public async Task<bool> ParkShipAsync(double shipLength, ParkingHouse parkingHouse)
        {
            await Task.Delay(1);

            bool condition = false;
            if ((parkingHouse.Capacity - shipLength) > 0)
            {
                condition = true;
            }
            return condition;
        }

        public async Task<bool> IsParkedAsync(SpaceTraveller spaceTraveller)
        {
            await Task.Delay(1);
            return false;
        }

        public Parking RestoreCapacity(Parking parking)
        {
            throw new NotImplementedException();
        }

        public bool CheckIfParked(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Parking> EndParkingAsync(SpaceTraveller spaceTraveller)
        {
            await Task.Delay(1);

            if (spaceTraveller.Name == "Obi-Wan Kenobi")
            {
                var obiPark = new Parking()
                {
                    SpaceTraveller = spaceTraveller,
                    ArrivalTime = Convert.ToDateTime("2021 - 05 - 05 14:43"),
                    DepartureTime = Convert.ToDateTime("2021 - 05 - 06 01:12")
                };
                DateTime start = obiPark.ArrivalTime;
                DateTime end = (DateTime)obiPark.DepartureTime;
                obiPark.Cost = (int)(Math.Round(((end - start).TotalMinutes), 0) * 250);
                return obiPark;
            }

            return null;
        }

        public async Task<List<HistoryDTO>> ParkingHistoryAsync(string name)
        {
            await Task.Delay(1);
            if (name == "Obi-Wan Kenobi")
            {

                var history = new List<HistoryDTO>();

                history.Add(new HistoryDTO
                {
                    Name = "Obi-Wan Kenobi",
                    StarShipModel = "Trade Federation cruiser",
                    ArrivalTime = Convert.ToDateTime("2020 - 05 - 05 14:43"),
                    DepartureTime = Convert.ToDateTime("2020 - 05 - 06 15:47"),
                    Cost = 20136,
                    ParkingHouse = "Naboo Galleria"
                });
                history.Add(new HistoryDTO
                {
                    Name = "Obi-Wan Kenobi",
                    StarShipModel = "Trade Federation cruiser",
                    ArrivalTime = Convert.ToDateTime("2020 - 08 - 13 14:43"),
                    DepartureTime = Convert.ToDateTime("2020 - 08 - 03 15:47"),
                    Cost = 8136,
                    ParkingHouse = "Naboo Galleria"
                });
                history.Add(new HistoryDTO
                {
                    Name = "Obi-Wan Kenobi",
                    StarShipModel = "Naboo star skiff",
                    ArrivalTime = Convert.ToDateTime("2020 - 10 - 01 14:43"),
                    DepartureTime = Convert.ToDateTime("2020 - 10 - 03 12:49"),
                    Cost = 88143,
                    ParkingHouse = "Naboo Galleria"
                });
                return history;
            }

            return null;

        }
    }
}
