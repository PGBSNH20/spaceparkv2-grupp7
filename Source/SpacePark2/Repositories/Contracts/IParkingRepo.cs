using SpacePark2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark2.Repositories
{
    public interface IParkingRepo
    {
        Task AddNewParking(ParkingHouse parkingHouse, SpaceTraveller traveller, StarShip starShip);
        Task AddParking(Parking parking);
    }
}
