using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SpacePark2.Models
{
    public class ParkingHouse
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Capacity { get; set; }

        public ParkingHouse()
        {

        }
    }
}
