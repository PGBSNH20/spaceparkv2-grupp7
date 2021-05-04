using Microsoft.EntityFrameworkCore;
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
        public async Task<Parking> EndParking(SpaceTraveller traveller)
        {
            var onGoingParking = await _context.Parking.Include(s => s.SpaceTraveller)
                .Where(s => s.SpaceTraveller == traveller)
                .FirstOrDefaultAsync(x => x.DepartureTime == null);
            if (onGoingParking != null)
            {
                int cost = CostOfParking(TimeParked(onGoingParking));
                await Update(new[] { (onGoingParking.DepartureTime = DateTime.Now, onGoingParking.Cost = cost) });
                return onGoingParking;
            }
            return null;
        }
        public async Task<List<Parking>> History(SpaceTraveller traveller)
        {
            await Task.Delay(1);
            return await _context.Parking
                  .Include(x => x.SpaceTraveller)
                  .ThenInclude(xs => xs.Name).ToListAsync();
            //.Include(s => s.StarShip) (t as Derived).MyProperty
            //  .ThenInclude(p => p.StarShipModel))
            //.Include(p => p.ParkingHouse)
            //.ThenInclude(p => p.Name)
            //.Where(s => s.SpaceTraveller == traveller && s.DepartureTime != null).ToListAsync();
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

    }
}
