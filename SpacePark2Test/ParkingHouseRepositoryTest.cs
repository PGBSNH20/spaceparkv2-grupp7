﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpacePark2.Models;
using SpacePark2.Repositories;

namespace SpacePark2Test
{
    class ParkingHouseRepositoryTest : IParkingHouseRepository
    {
        public Task Post(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<ParkingHouse>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<ParkingHouse> Get(string name)
        {
            if (name == "NabooGalleria")
                return new() {Name = name, Capacity = 987.6};

            return null;
        }
    }
}
