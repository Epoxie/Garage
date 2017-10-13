using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;
//using Newtonsoft.Json;
using System.IO;

namespace Garage
{
    class Program
    {
        static CreateVehicle create = new CreateVehicle();
        static Garage garage = new Garage();
        static double pricePerSecond = 2;
        

        
        //Main menu
        static void MainMenu()
        {
            Regex regex = new Regex(@"[^\d]");
            bool runMain = true;
            

            while (runMain)
            {
                //Declares a parseint struct and clears console before every loop
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("(-(-.(-.-) Das Garage (-.-).-)-)");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("0: Exit\n" +
                    "1: Display Vehicle/Vehicles\n" +
                    "2: Check In\n" +
                    "3: Check Out\n" +
                    "4: Search By");

                char input;
                try
                {
                    input = Console.ReadLine()[0];
                }
                catch 
                {
                    input = ' ';

                }

                string inputs = "";

                switch (input)
                {
                    case '0':
                        runMain = false;
                        break;
                    case '1':
                        //Return basic info for all vehicles
                        Console.WriteLine("Type in a registration number or leave blank");

                        inputs = Console.ReadLine();

                        if (inputs.Trim().Equals(""))

                        {
                            foreach (var vehicle in garage.GetAllVehicles())
                            {
                                Console.WriteLine(vehicle.BasicInfo());
                            }
                        }

                        else
                        {
                            try
                            {
                                Console.WriteLine(garage.SearchByRegNr(inputs).ElementAt(0).ToString());
                            }
                            catch { Console.WriteLine("Could not find that vehicle."); }
                        }
                        //Return all info for a specific vehicle by reg number
                        Console.ReadKey();
                        break;
                    case '2':
                        create.FinalizeCar(garage);
                        break;
                    case '3':
                        Console.WriteLine("Registration number: ");
                        inputs = Console.ReadLine();

                        Vehicle vehicleToRemove = null;
                        try
                        {
                            vehicleToRemove = garage.SearchByRegNr(inputs).ElementAt(0);
                        }
                        catch { Console.WriteLine("Couldn't find that Vehicle."); }
                        

                        if (vehicleToRemove != null)
                        {
                            double time = DateTime.Now.Subtract(vehicleToRemove.ParkTime).TotalSeconds;
                            double price = pricePerSecond * time;
                            Console.WriteLine("{2} parked at spot {3}. Price for {0} seconds, is {1} kronor", time, price, vehicleToRemove.RegNr, garage.ParkingSpace(vehicleToRemove));
                            Console.WriteLine("Do you want to accept y or cancel n?");
                            char confirm = Console.ReadLine()[0];

                            if (confirm == 'y')
                            {
                                garage.RemoveVehicle(vehicleToRemove);
                            }

                            Console.WriteLine("The vehicle was removed");
                        }

                        
                        break;
                    case '4':
                        Console.Clear();
                        List<Vehicle> newVList;
                        Console.Write("Registration Number: ");
                        string newRegNr = Console.ReadLine();
                        Console.Write("Model: ");
                        string newModel = Console.ReadLine();
                        Console.Write("Color: ");
                        string newColor = Console.ReadLine();
                        Console.Write("Brand: ");
                        string newBrand = Console.ReadLine();
                        Console.WriteLine("Time of Parking? (y/n)");
                        string newInput = Console.ReadLine();
                        try
                        {
                            if (newInput[0] == 'y')
                            {
                                regex = new Regex(@"[^\d]");
                                Console.Write("Time in year: ");
                                int newYear = Int32.Parse(regex.Replace(Console.ReadLine(), ""));
                                Console.Write("Month: ");
                                int newMonth = Int32.Parse(regex.Replace(Console.ReadLine(), ""));
                                Console.Write("Day: ");
                                int newDay = Int32.Parse(regex.Replace(Console.ReadLine(), ""));
                                Console.Write("Hour: ");
                                int newHour = Int32.Parse(regex.Replace(Console.ReadLine(), ""));
                                Console.Write("Minute: ");
                                int newMinute = Int32.Parse(regex.Replace(Console.ReadLine(), ""));
                                Console.Write("Second: ");
                                int newSecond = Int32.Parse(regex.Replace(Console.ReadLine(), ""));
                                newVList = garage.SearchWithOptions(newRegNr, newModel, newColor, newBrand, new DateTime(newYear, newMonth, newDay, newHour, newMinute, newSecond));
                            }
                            else
                                newVList = garage.SearchWithOptions(newRegNr, newModel, newColor, newBrand);
                        } catch
                        {
                            newVList = garage.SearchWithOptions(newRegNr, newModel, newColor, newBrand);
                        }
                        foreach (Vehicle v in newVList)
                        {
                            Console.WriteLine(v.ToString());
                        }
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Not a valid option!");
                        break;
                }
            }
        }


        static void Main(string[] args)
        {
            // add some testVehicle string RegNr, string Model, string Color, string Brand, int ProdYear
            garage.AddVehicle(new Car("123-456", "Ö-7000", "Super Blue", "Örjans Egna Bilmärke", 1975));
            // add some testVehicle string RegNr, string Model, string Color, string Brand, int Class
            garage.AddVehicle(new Motorcycle("FUCK-YOU", "SpeedBike", "Very Red", "Fraticelli", 5));

            //SaveToFile(garage.GetAllVehicles());

            MainMenu();

        }

        //static void SaveToFile(List<Vehicle> saveList)
        //{
        //    using (StreamWriter file = File.CreateText(@"C:\Users\elev\source\repos\Garage\data\testSave.txt"))
        //    {
        //        JsonSerializer serializer = new JsonSerializer();
        //        //serialize object directly into file stream
        //        foreach (Vehicle v in saveList)
        //        {
        //            serializer.Serialize(file, v.ToList().ToArray());
        //        }
        //    }
        //}
    }
}
