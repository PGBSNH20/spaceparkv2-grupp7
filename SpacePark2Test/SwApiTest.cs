using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using Service.Repository.Contracts;

namespace SpacePark2Test
{
    class SwApiTest : ISwApi
    {
        public Task<T> GetStarWarsObject<T>(string path)
        {
            // behöver inte implementeras, används av de andra tre
            throw new NotImplementedException();
        }

        public Task<SpaceTraveller> GetSpaceTraveller(string name)
        {
            // behöver name(string) och starships(string[])
            // Första testet kommer fråga efter Obi-Wan Kenobi
            throw new NotImplementedException();
        }

        public Task<List<string>> ChooseStarShip(SpaceTraveller person)
        {
            // returnerar en lista med namn på starships i lowercase
            // Obi-Wan Kenobi kommer med sina skepp
            throw new NotImplementedException();
        }

        public Task<double> GetShipLength(string shipName)
        {
            // gör en if-sats som returnerar längd per skepp
            // Börja med Obi-Wan Kenobi's skepp
            throw new NotImplementedException();
        }
    }
}
