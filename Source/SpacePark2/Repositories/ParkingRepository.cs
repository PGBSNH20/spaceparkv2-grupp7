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
      
        public async Task AddParking(Parking parking)
        {
            await Add(parking);
        }

        public async Task<Parking> EndParking(Models.SpaceTraveller traveller)
        {
            var onGoingParking = await _context.Parking.Include(s => s.SpaceTraveller)
                .Where(s => s.SpaceTraveller == traveller)
                .FirstOrDefaultAsync(x => x.DepartureTime == null);
            if (onGoingParking != null)
            {
                onGoingParking.DepartureTime = DateTime.Now;
                onGoingParking.Cost = CostOfParking(TimeParked(onGoingParking));
                await Update(onGoingParking);
                return onGoingParking;
            }
            return null;
        }

        public async Task<List<Parking>> History(Models.SpaceTraveller traveller)
        {

            return await _context.Parking
                  .Include(x => x.SpaceTraveller)
                  .Include(x => x.StarShip)
                  .Include(x => x.ParkingHouse)
                  .Where(p => p.SpaceTraveller == traveller).ToListAsync();
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
        }

        public async Task<bool> CheckCapacity(double shipLength, ParkingHouse parkingHouse)
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

        public async Task<bool> CheckIfParked(Models.SpaceTraveller spaceTraveller)
        {
            
            var query = await _context.Parking.Include(x => x.SpaceTraveller).Where(x => x.SpaceTraveller == spaceTraveller).FirstOrDefaultAsync(x => x.DepartureTime == null);
            if (query != null)
                return true;
            return false;
        }
    }
}
