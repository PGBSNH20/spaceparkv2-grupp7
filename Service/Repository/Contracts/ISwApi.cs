using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Repository.Contracts
{
    public interface ISwApi
    {
        Task<T> GetStarWarsObject<T>(string path);
        Task<SpaceTraveller> GetSpaceTraveller(string name);
        Task<List<string>> ChooseStarShip(SpaceTraveller spaceTraveller);
        Task<double> GetShipLength(string shipName);
    }
}