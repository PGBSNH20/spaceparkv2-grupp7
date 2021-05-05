using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class SearchResultStarShip
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public Starship[] results { get; set; }
    }
}
