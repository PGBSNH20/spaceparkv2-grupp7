using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace SpacePark2.Repositories
{
    public interface ISpaceTravellerRepo
    {
        Task<string> GetSpaceTravellerByName(string name);
    }
}