using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    class Program
    {
        static void Main(string[] args)
        {
            var swapi = new SwApi();
            var something = swapi.GetSpaceTraveller("yoda");
            Console.WriteLine(something.Result.eye_color);
        }
    }
}
