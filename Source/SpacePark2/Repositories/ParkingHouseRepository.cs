using Microsoft.EntityFrameworkCore;
using SpacePark2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark2.Repositories
{
    public class ParkingHouseRepository :Repository, IParkingHouseRepository
    {
        public ParkingHouseRepository(SpaceParkContext context) : base(context) { }

        public async Task<List<ParkingHouseDTO>> Get()
        {
            var searchResultList = await _context.ParkingHouse.ToListAsync();
            var resultList = new List<ParkingHouseDTO>();
            foreach (var s in searchResultList)
            {
               resultList.Add(new ParkingHouseDTO(){ Name = s.Name, Capacity = s.Capacity });
            }
            return resultList;
        }

        public async Task<ParkingHouse> Get(string name)
        {
            return await _context.ParkingHouse.FirstOrDefaultAsync(x => x.Name.ToLower() == name);
        }

        public async Task AddNewParkingHouseAsync(string name, double capacity)
        {
            await Add(new ParkingHouse { Name = name, Capacity = capacity });
        }
    }
}
