using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Service
{
    public class SpaceTraveller
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("starships")]
        public string[] StarShips { get; set; }
    }

}
