using Microsoft.EntityFrameworkCore;
using Service;
using SpacePark2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark2.Repositories
{
    public class ParkingRepository : Repository, IParkingRepository
    {
        public ParkingRepository(SpaceParkContext context) : base(context) { }
      
        public async Task AddParkingAsync(Parking parking)
        {
            await Add(parking);
        }

        public async Task<Parking> EndParkingAsync(Models.SpaceTraveller spaceTraveller)
        {
            var onGoingParking = await _context.Parking.Include(s => s.SpaceTraveller)
                .Where(s => s.SpaceTraveller == spaceTraveller)
                .Include(s => s.StarShip)
                .Include(s => s.ParkingHouse)
                .FirstOrDefaultAsync(x => x.DepartureTime == null);

            if (onGoingParking != null)
            {
                onGoingParking.DepartureTime = DateTime.Now;
                onGoingParking.Cost = CostOfParking(TimeParked(onGoingParking));
                RestoreCapacity(onGoingParking);
                await Update(onGoingParking);
                return onGoingParking;
            }
            return null;
        }

        public Parking RestoreCapacity(Parking parking)
        {
            parking.ParkingHouse.Capacity += parking.StarShip.ShipLength;
            return parking;
        }

        public async Task<List<Parking>> GetHistoryAsync(Models.SpaceTraveller traveller)
        {
            return await _context.Parking
                  .Include(x => x.SpaceTraveller)
                  .Include(x => x.StarShip)
                  .Include(x => x.ParkingHouse)
                  .Where(p => p.SpaceTraveller == traveller).ToListAsync();
        }
        public async Task<bool> ParkShipAsync(double shipLength, ParkingHouse parkingHouse)
        {
            bool condition = false;
            if ((parkingHouse.Capacity - shipLength) > 0)
            {
                parkingHouse.Capacity -= shipLength;
                await Update(parkingHouse);
                condition = true;
            }
            return condition;
        }

        public async Task<bool> IsParkedAsync(Models.SpaceTraveller spaceTraveller)
        {
            var query = await _context.Parking
                .Include(x => x.SpaceTraveller)
                .Where(x => x.SpaceTraveller == spaceTraveller)
                .FirstOrDefaultAsync(x => x.DepartureTime == null);
            if (query != null)
                return true;
            return false;
        }
        public double TimeParked(Parking vehicle)
        {
            DateTime start = (DateTime)vehicle.ArrivalTime;
            DateTime end = DateTime.Now;
            return (end - start).TotalMinutes;
        }

        public int CostOfParking(double timeParked)
        {
            return (int)(Math.Round(timeParked, 0) * 250);
        public async Task<List<HistoryDTO>> ArchiveParkingAsync(string name)
        {
            var traveller = await _context.SpaceTraveller.FirstOrDefaultAsync(x => x.Name == name);

            var parkingList = await _context.Parking
                .Include(x => x.StarShip)
                .Include(x => x.ParkingHouse)
                .Where(x => x.SpaceTraveller.Name == traveller.Name)
                .ToListAsync();

            var historyList = new List<HistoryDTO>();
            foreach (var r in parkingList)
            {
                historyList.Add(new HistoryDTO()
                {
                    Name = traveller.Name,
                    StarShipModel = r.StarShip.StarShipModel,
                    ParkingHouse = r.ParkingHouse.Name,
                    Cost = r.Cost,
                    ArrivalTime = r.ArrivalTime,
                    DepartureTime = (DateTime)r.DepartureTime
                });
            }
            return historyList;
        }
    }
}
