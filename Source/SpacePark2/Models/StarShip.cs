using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark2.Models
{
    public class StarShip
    {
        public Guid Id { get; set; }
        public string StarShipModel { get; set; }
        public double ShipLength { get; set; }

        public StarShip()
        {

        }
    }
}
