﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark2.Repositories
{
    public class ParkingHouseRepository :Repository,IParkingHouseRepository
    {
        public ParkingHouseRepository(SpaceParkContext context) : base(context) { }
        
    }
}