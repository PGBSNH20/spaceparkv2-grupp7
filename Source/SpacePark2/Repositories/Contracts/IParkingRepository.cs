using SpacePark2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark2.Repositories
{
    public interface IParkingRepository
    {
        Task AddParkingAsync(Parking parking);
        Task<Parking> EndParkingAsync(SpaceTraveller spaceTraveller);
        Task<bool> ParkShipAsync(double shipLength, ParkingHouse parkingHouse);
        Task<bool> IsParkedAsync(SpaceTraveller spaceTraveller);
        Parking RestoreCapacity(Parking parking);
        Task<List<HistoryDTO>> ParkingHistoryAsync(SpaceTraveller spaceTraveller);
    }
}
