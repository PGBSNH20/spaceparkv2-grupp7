using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpacePark2.Models;

namespace SpacePark2.Repositories
{
    public class SpaceTravellerRepo : Repository, ISpaceTravellerRepo
    {
        public SpaceTravellerRepo(SpaceParkContext context) : base(context) { }


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

        public async Task EndParking(string name)
        {
            var traveller = await _context.SpaceTraveller.SingleOrDefaultAsync(x => x.Name == name);
            var onGoingParking = await _context.Parking.Include(p => p.SpaceTraveller == traveller)
                .FirstOrDefaultAsync(x => x.DepartureTime == null);
            int cost = CostOfParking(TimeParked(onGoingParking));

            await Update(new[] { (onGoingParking.DepartureTime = DateTime.Now, onGoingParking.Cost = cost) });

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

        //public async Task<string> GetSpaceTravellerByName(string name)
        //{
        //    // dbcontext tjafs
        //    await Task.Delay(1);
        //    return $"Habitant {name}";
        //}

    }
}
