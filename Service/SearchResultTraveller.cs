using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class SearchResultTraveller
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public SpaceTraveller[] results { get; set; }
    }
}
