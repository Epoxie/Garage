﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    class Vehicle
    {
        public string RegNr { get; set; }
        public string Model { get; set;}
        public DateTime ParkTime { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public enum Vtype
        {
            Bus,
            Car,
            Truck,
            Motorcycle
        }

        public Vtype V;

        public  string BasicInfo()
        {
            return "RegNr: " + RegNr + "\n-Vehicle Type: " + v;
        }
        
        public override string ToString()
        {

            return "RegNr: " +RegNr +"\n-Brand: " +Brand + "\n--Model: " + Model + "\n---Color: " + Color + "\n----Time Parked: " + ParkTime;
        }

        public Vehicle()
        {

        }

        public Vehicle(DateTime ParkTime)
        {
            ParkTime = DateTime.Now;
        }

        public Vehicle(string RegNr, string Model, string Color, string Brand)
        {
            this.RegNr = RegNr;
            this.Model = Model;
            ParkTime = DateTime.Now;
            this.Color = Color;
            this.Brand = Brand;
        }
    }
}