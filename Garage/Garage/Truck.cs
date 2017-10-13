using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    class Truck : Vehicle
    {
        public string Size { get; set; }

        public Truck()
        {

        }

        public Truck(string RegNr, string Model, string Color, string Brand, string Size) : base(RegNr, Model, Color, Brand)
        {
            this.V = Vtype.Truck;
            this.Size = Size;
        }

        public override List<string> ToList()
        {
            return new List<string>() { "Truck", RegNr, Model, Color, Brand, Size.ToString(), ParkTime.ToString() };
        }
    }
}
