using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;



namespace Service
{
    public class SwApi : IDisposable
    {
        public string Name { get; set; }
        private string NamePath { get; set; }
        public string ShipName { get; set; }
        public string ShipPath { get; set; }

        readonly HttpClient Client = new();

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
            SearchResultTraveller search = null;
            NamePath = $"https://swapi.dev/api/people/?search={name}";


            if(name != null)
            search = await GetStarWarsObject<SearchResultTraveller>(NamePath);

            if(search !=null && search.results[0].Name.ToLower() == name.ToLower())
               return search.results[0];

            return null;
           
        }

        public async Task<List<string>> ChooseStarShip(SpaceTraveller person)
        {
            List<string> starShips = new();
            if (!person.StarShips.Any())
            {
                return null;
            }

            foreach (var starShip in person.StarShips)
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
            
            return double.Parse(starShip.results[0].length.Replace('.',','));
        }

        public void Dispose()
        {
            Client?.Dispose();
        }
    }
}
