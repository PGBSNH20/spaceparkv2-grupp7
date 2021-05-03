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
       // public double ShipLength { get; set; }

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
            NamePath = $"https://swapi.dev/api/people/?search={name}";
            var search = await GetStarWarsObject<SearchResultTraveller>(NamePath);
         
            try
            {
                if (search.results[0].Name.ToLower() == name.ToLower())
                {
                    return search.results[0];
                }
                else
                {
                    
                    Console.WriteLine("You have entered an invalid name, please enter your full name.");
                }
            }
            catch (Exception)
            {
                // TODO Hantera här!!
                Console.WriteLine("You are not famous and can't access this spacepark.");
                await Task.Delay(2000);
            };

            return null;
        }

        //public async Task<string> ChooseStarShip(SpaceTraveller person)
        //{
        //    var menu = new Menu();
        //    List<string> starShips = new();
        //    if (!person.StarShips.Any())
        //    {
        //        Console.WriteLine("You don't have a spaceship to park. Next, please!");
        //        await Task.Delay(2000);
        //        return null;
        //    }

        //    foreach (var starShip in person.StarShips)
        //    {
        //        var search = await GetStarWarsObject<Starship>(starShip);
        //        starShips.Add(search.Name);
        //    }

        //    int starShipIndex = menu.ShowMenu("Choose Starship to park: ", starShips);

        //    return starShips[starShipIndex];
        //}

        public async Task<double> GetShipLength(string path)
        {
            ShipPath = $"https://swapi.dev/api/starships/?search={path}";

            var starShip = await GetStarWarsObject<SearchResultStarShip>(ShipPath);
            
            return double.Parse(starShip.results[0].length.Replace('.',','));
        }

        public void Dispose()
        {
            Client?.Dispose();
        }
    }
}
