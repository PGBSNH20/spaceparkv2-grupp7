using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Repository.Contracts
{
    public interface ISwApi
    {
        Task<T> GetStarWarsObjectAsync<T>(string path);
        Task<SpaceTraveller> GetSpaceTravellerAsync(string name);
        Task<List<string>> ChooseStarShipAsync(SpaceTraveller spaceTraveller);
        Task<double> GetShipLengthAsync(string shipName);
    }
}