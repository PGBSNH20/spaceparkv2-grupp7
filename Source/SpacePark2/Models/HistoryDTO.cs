using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark2.Models
{
    public class HistoryDTO
    {
        public string Name { get; set; }
        public string StarShipModel { get; set; }
        public string ParkingHouse { get; set; }
        public int Cost { get; set; }
        public DateTime ArrivalTime { get; set; } 
        public DateTime DepartureTime { get; set; }
    }
}
