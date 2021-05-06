﻿using SpacePark2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark2.Repositories
{
    public interface IParkingRepository
    {
        Task AddParkingAsync(Parking parking);
        Task<Parking> EndParkingAsync(SpaceTraveller traveller);
        Task<List<Parking>> CheckHistoryAsync(SpaceTraveller traveller);
        Task<bool> ParkShipAsync(double shipLength, ParkingHouse parkingHouse);
        Task<bool> CheckIfParkedAsync(SpaceTraveller spaceTraveller);
    }
}
