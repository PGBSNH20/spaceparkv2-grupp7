using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpacePark2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePark2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        private readonly SpaceParkContext _context;
        private readonly IParkingRepo _repo;

        public ParkingController(SpaceParkContext context, IParkingRepo repo)
        {
            _context = context;
            _repo = repo;
        }
    }
}
