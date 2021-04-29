using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark2.Models
{
    public class Parking
    {
        public int Id { get; set; }
        public ParkingHouse ParkingHouseId { get; set; }
        public SpaceTraveller SpaceTravellerId { get; set; }
        public StarShip StarShipId  { get; set; }
        public DateTime ArrivalTime { get; set; } = DateTime.Now;
        public  DateTime? DepartureTime { get; set; }
        public int Cost { get; set; } = 0;

    }
}
