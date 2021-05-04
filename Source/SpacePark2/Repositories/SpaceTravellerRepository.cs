using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpacePark2.Models;

namespace SpacePark2.Repositories
{
    public class SpaceTravellerRepository : Repository, ISpaceTravellerRepository
    {
        public SpaceTravellerRepository(SpaceParkContext context) : base(context) { }


        public SpaceTraveller CreateSpaceTraveller(SpaceTraveller existingTraveller, Service.SpaceTraveller newTraveller)
        {
            if (existingTraveller != null)
                return existingTraveller;

            return new SpaceTraveller { Name = newTraveller.Name };
        }
        public async Task<SpaceTraveller> Get(string name)
        {
            return await _context.SpaceTraveller.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<Parking> EndParking(SpaceTraveller traveller)
        {
            var onGoingParking = await _context.Parking.Include(p => p.SpaceTraveller)
                .Where(p => p.SpaceTraveller == traveller)
                .FirstOrDefaultAsync(x => x.DepartureTime == null);
            if (onGoingParking != null)
            {
                int cost = CostOfParking(TimeParked(onGoingParking));
                await Update(new[] { (onGoingParking.DepartureTime = DateTime.Now, onGoingParking.Cost = cost) });
                return onGoingParking;
            }
            return null;
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
