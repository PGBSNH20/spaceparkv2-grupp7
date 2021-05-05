using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Service.Repository.Contracts;

namespace Service.Repository
{
    public class SwApi : IDisposable, ISwApi
    {
        public string Name { get; set; }
        private string NamePath { get; set; }
        public string ShipName { get; set; }
        public string ShipPath { get; set; }

        readonly HttpClient Client = new();
        // TODO Kolla så allt har ToLower

        public async Task<T> GetStarWarsObject<T>(string path)
        {
            string baseUrl = $"{path}";
            T result = default;
            try
            {
                using (HttpResponseMessage res = await Client.GetAsync(baseUrl))
                using (HttpContent content = res.Content)
                {
                    var data = await content.ReadAsStringAsync();
                    if (content != null)
                    {
                        result = JsonConvert.DeserializeObject<T>(data);
                    }
                    else
                    {

                        Console.WriteLine("Error fetching data!");
                    }
                }
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            return result;
        }

        public async Task<SpaceTraveller> GetSpaceTraveller(string name)
        {

            if (name != null)
            {
                NamePath = $"https://swapi.dev/api/people/?search={name}";
                var search = await GetStarWarsObject<SearchResultTraveller>(NamePath);

                if (search.count > 0 && search.results[0].Name.ToLower() == name.ToLower())
                    return search.results[0];
            }

            return null;
        }

        public async Task<List<string>> ChooseStarShip(SpaceTraveller spaceTraveller)
        {
            List<string> starShips = new();
            if (!spaceTraveller.StarShips.Any())
            {
                return null;
            }

            foreach (var starShip in spaceTraveller.StarShips)
            {
                var search = await GetStarWarsObject<Starship>(starShip);
                starShips.Add(search.Name.ToLower());
            }

            return starShips;
        }

        public async Task<double> GetShipLength(string shipName)
        {
            ShipPath = $"https://swapi.dev/api/starships/?search={shipName}";

            var starShip = await GetStarWarsObject<SearchResultStarShip>(ShipPath);

            return double.Parse(starShip.results[0].length.Replace('.', ','));
        }

        public void Dispose()
        {
            Client?.Dispose();
        }
    }
}
