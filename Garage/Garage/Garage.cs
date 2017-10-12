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

        public List<Vehicle> SearchByRegnr(string regnr)
        {
            var returnVehicle =
                from v in GarageList
                where v.RegNr == regnr
                select v;
            return returnVehicle.ToList();
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

        public List<Vehicle> SearchWithOptions(string RegNr = "", string Model = "", string Color = "", string Brand = "", DateTime ParkTime = new DateTime())
        {
            var returnList =
                from v in GarageList
                where v.ParkTime >= ParkTime
                where v.RegNr.ToLower().Contains(RegNr.ToLower())
                where v.Model.ToLower().Contains(Model.ToLower())
                where v.Color.ToLower().Contains(Color.ToLower())
                where v.Brand.ToLower().Contains(Brand.ToLower())
                select v;
            return returnList.ToList();
        }
    }
}
