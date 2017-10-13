using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    class Motorcycle : Vehicle
    {
        public int Class { get; set; }

        public Motorcycle()
        {

        }

        public Motorcycle(string RegNr, string Model, string Color, string Brand, int Class) : base(RegNr, Model, Color, Brand)
        {
            this.V = Vtype.Motorcycle;
            this.Class = Class;
        }
    }
}
