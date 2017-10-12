using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    class Bus : Vehicle
    {
        public string Size { get; set; }
        public int Seats { get; set; }

        public Bus()
        {

        }

        public Bus(string RegNr, string Model, string Color, string Brand, string Size, int Seats) : base(RegNr, Model, Color, Brand)
        {
            this.v = Vtype.Car;
            this.Size = Size;
            this.Seats = Seats;
        }
    }
}
