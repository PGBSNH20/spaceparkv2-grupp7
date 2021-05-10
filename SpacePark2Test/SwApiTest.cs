using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service;
using Service.Repository.Contracts;

namespace SpacePark2Test
{
    class SwApiTest : ISwApi
    {
        private static List<string> starShips = new()
        {
            "jedi starfighter", 
            "trade federation cruiser", 
            "naboo star skiff", 
            "jedi interceptor",
            "belbullab-22 starfighter"
        };

        private Service.SpaceTraveller ObiWan = new()
        {
            Name = "Obi-Wan Kenobi",
            StarShips = starShips.ToArray()
        };

        public Task<T> GetStarWarsObjectAsync<T>(string path)
        {
            throw new NotImplementedException();
        }

        public async Task<SpaceTraveller> GetSpaceTravellerAsync(string name)
        {
            if (name != "Obi-Wan Kenobi")
                return null;

            return ObiWan;
        }

        public async Task<List<string>> ChooseStarShipAsync(SpaceTraveller spaceTraveller)
        {
            if (!spaceTraveller.StarShips.Any())
            {
                return null;
            }

            return starShips;
        }

        public async Task<double> GetShipLengthAsync(string shipName)
        {
            switch (shipName.ToLower())
            {
                case "jedi starfighter":
                    return 8.0;
                case "trade federation cruiser":
                    return 1088.0;
                case "naboo star skiff":
                    return 29.2;
                case "jedi interceptor":
                    return 5.47;
                case "belbullab-22 starfighter":
                    return 6.71;
                default:
                    return default;
            }
        }
    }
}
