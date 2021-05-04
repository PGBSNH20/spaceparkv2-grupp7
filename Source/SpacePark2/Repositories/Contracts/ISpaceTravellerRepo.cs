using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SpacePark2.Models;

namespace SpacePark2.Repositories
{
    public interface ISpaceTravellerRepo : IRepository
    {
        Task<SpaceTraveller> Get(string name);
        Task Update(string name);
    }
}