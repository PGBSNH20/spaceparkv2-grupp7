﻿using Microsoft.EntityFrameworkCore;
using SpacePark2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark2.Repositories
{
    public class ParkingHouseRepository :Repository,IParkingHouseRepository
    {
        public ParkingHouseRepository(SpaceParkContext context) : base(context) { }

        public async Task<List<ParkingHouse>> Get()
        {
          return  await _context.ParkingHouse.ToListAsync();
        }

        public async Task Post(string name)
        {
            await Add(name);
        }
    }
}
