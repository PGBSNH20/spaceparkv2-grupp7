using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark2.Models
{
    public class Parking
    {
        public Guid Id { get; set; }
        public ParkingHouse ParkingHouse { get; set; }
        public SpaceTraveller SpaceTraveller { get; set; }
        public StarShip StarShip  { get; set; }
        public DateTime ArrivalTime { get; set; } = DateTime.Now;
        public  DateTime? DepartureTime { get; set; }
        public int Cost { get; set; } = 0;

        public Parking()
        {
        }
    }
}
