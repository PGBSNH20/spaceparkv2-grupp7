using SpacePark2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark2.Repositories
{
    public interface IParkingRepository
    {
        Task AddParking(Parking parking);
        Task<Parking> EndParking(SpaceTraveller traveller);
        Task<List<Parking>> History(SpaceTraveller traveller);

    }
}
