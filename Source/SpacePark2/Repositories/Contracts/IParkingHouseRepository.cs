﻿using SpacePark2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark2.Repositories
{
    public interface IParkingHouseRepository
    {
        Task Post(string name);
        Task<List<ParkingHouse>> Get();
        Task<ParkingHouse> Get(string name);
    }
}
