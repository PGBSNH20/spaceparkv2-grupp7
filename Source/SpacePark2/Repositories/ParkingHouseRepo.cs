using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark2.Repositories
{
    public class ParkingHouseRepo :Repository,IParkingHouseRepo
    {
        public ParkingHouseRepo(SpaceParkContext context) : base(context) { }
        
    }
}
