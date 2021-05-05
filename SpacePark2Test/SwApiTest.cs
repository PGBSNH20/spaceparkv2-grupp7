﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Service;
using Service.Repository.Contracts;

namespace SpacePark2Test
{
    class SwApiTest : ISwApi
    {
        private static List<string> starShips = new List<string>()
        {
            "jedi starfighter", "trade federation cruiser", "naboo star skiff", "jedi interceptor",
            "belbullab-22 starfighter"
        };

        private Service.SpaceTraveller ObiWan = new SpaceTraveller()
        {
            Name = "Obi-Wan Kenobi",
            StarShips = starShips.ToArray()
        };

        public Task<T> GetStarWarsObject<T>(string path)
        {
            // Behöver inte implementeras, används av de andra tre
            throw new NotImplementedException();
        }

        public async Task<SpaceTraveller> GetSpaceTraveller(string name)
        {
            return ObiWan;
        }

        public async Task<List<string>> ChooseStarShip(SpaceTraveller spaceTraveller)
        {
            return starShips;
        }

        public async Task<double> GetShipLength(string shipName)
        {
            switch (shipName)
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
                    return default; //TODO detta är INTE rätt
            }
        }
    }
}
