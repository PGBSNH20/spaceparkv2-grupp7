using SpacePark2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark2.Repositories
{
    public interface IStarShipRepo : IRepository
    {
        Task Post(StarShip starShip);
        
    }
}
