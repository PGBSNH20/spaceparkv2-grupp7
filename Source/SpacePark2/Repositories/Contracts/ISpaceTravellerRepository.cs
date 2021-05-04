using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SpacePark2.Models;

namespace SpacePark2.Repositories
{
    public interface ISpaceTravellerRepository : IRepository
    {
        Task<SpaceTraveller> Get(string name);
     
        SpaceTraveller CreateSpaceTraveller(SpaceTraveller existingTraveller, Service.SpaceTraveller newTraveller);

    }
}