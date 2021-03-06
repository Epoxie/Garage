﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    class Garage
    {
        List<Vehicle> GarageList = new List<Vehicle>();
        int SizeOfGarage = 6;

        public Garage()
        {
            for (int i = 0; i < SizeOfGarage; i++)
            {
                GarageList.Add(null);
            }
        }

        public List<Vehicle> SearchByRegNr(string regnr)
        {
            var returnVehicle =
                from v in GarageList
                where v != null
                where v.RegNr == regnr
                select v;
            return returnVehicle.ToList();
        }

        public List<Vehicle> GetAllVehicles()
        {
            List<Vehicle> retList = new List<Vehicle>();

            foreach (var vehicle in GarageList)
            {
                if (vehicle != null)
                {
                    retList.Add(vehicle);
                }
            }

            return retList;
        }

        public bool AddVehicle(Vehicle newVehicle)
        {
            for (int i = 0; i < SizeOfGarage; i++)
            {
                if (GarageList[i] == null)
                {
                    GarageList[i] = newVehicle;
                    return true;
                }
            }
            return false;
        }

        public void RemoveVehicle(Vehicle removeVehicle)
        {
            GarageList[GarageList.IndexOf(removeVehicle)] = null;
        }

        public int ParkingSpace(Vehicle parkedVehicle)
        {
            return GarageList.IndexOf(parkedVehicle) + 1;
        }

        public bool RegNrExists(String RegNr)
        {
            foreach (Vehicle vehicle in GarageList)
            {
                if (vehicle != null)
                {
                    if (vehicle.RegNr == RegNr)
                        return true;
                }
            }
            return false;
        }

        public List<Vehicle> SearchWithOptions(string RegNr = "", string Model = "", string Color = "", string Brand = "", DateTime ParkTime = new DateTime())
        {
            var returnList =
                from v in GarageList
                where v != null
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
