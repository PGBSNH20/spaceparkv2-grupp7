using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SpacePark2.Models;

namespace SpacePark2.Repositories
{
    public interface ISpaceTravellerRepo : IRepository
    {
        Task<SpaceTraveller> Get(Guid id);
        Task<SpaceTraveller> Get(string name);
        Task Post(SpaceTraveller traveller);

    }
}