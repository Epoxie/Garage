using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    class Car : Vehicle
    {
        public int ProdYear { get; set; }

        public Car ()
        {

        }

        public Car(string RegNr, string Model, string Color, string Brand, int ProdYear) : base(RegNr, Model, Color, Brand)
        {
            this.V = Vtype.Car;
            this.ProdYear = ProdYear;
        }

        public override List<string> ToList()
        {
            return new List<string>() { "Car", RegNr, Model, Color, Brand, ProdYear.ToString(), ParkTime.ToString() };
        }
    }
}
