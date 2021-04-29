using System.Threading.Tasks;

namespace SpacePark2.Repositories
{
    public interface ISpaceParkRepo
    {
        Task<string> GetHabitantByName(string name);
    }
}