using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    class Garage
    {
        List<Vehicle> GarageList = new List<Vehicle>();

        public Garage()
        {
            // default constructor, could add default setup with some vehicles already here
        }

        public Vehicle SearchByRegnr(string regnr)
        {
            var returnVehicle =
                from v in GarageList
                where v.regnr == regnr
                select v;
            return returnVehicle;
        }

        public List<Vehicle> GetAllVehicles()
        {
            return GarageList;
        }

        public void AddVehicle(Vehicle newVehicle)
        {
            GarageList.Add(newVehicle);
        }

        public void removeVehicle(Vehicle removeVehicle)
        {
            GarageList.Remove(removeVehicle);
        }

        public List<Vehicle> SearchWithOptions(string RegNr = "", string Model = "", string Size = "", int Class = 0, int ProdYear = 0, int Seats = 0)
        {
            var returnList =
                from v in GarageList
                where v.RegNr.ToLower().Contains(RegNr.ToLower())
                where v.Model.ToLower()
        }
    }
}
