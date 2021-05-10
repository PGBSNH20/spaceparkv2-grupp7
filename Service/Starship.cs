using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Starship
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        public string length { get; set; }
    }
}
