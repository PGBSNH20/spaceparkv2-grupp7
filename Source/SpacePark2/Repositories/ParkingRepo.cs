using SpacePark2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark2.Repositories
{
    public class ParkingRepo : Repository, IParkingRepo
    {
        public ParkingRepo(SpaceParkContext context) : base(context) { }

        public Task AddNewParking(ParkingHouse parkingHouse, SpaceTraveller traveller, StarShip starShip)
        {
            /* Kolla om dessa finns i databasen ifrån start ta ID annars
             * Validera traveller, starship swapi, ge felkoder om de ej finns eller 
             * ej får köra det starShipet
             * om ja, validera parkinghouse sedan lägg till i databas 
             */
            throw new NotImplementedException();
        }
    }
}
