using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;


namespace Garage
{
    class Program
    {
        static Garage garage = new Garage();
        static double pricePerSecond = 2;

        public struct parseInt
        {
            public int ret;
            public bool success;
        };

        static parseInt ParseInputToInt(string input)
        {
            int ret = 0;
            parseInt pi = new parseInt();

            try
            {
                ret = int.Parse(input.Trim());
                pi.ret = ret;
                pi.success = true;

            }
            catch (Exception)
            {

                pi.success = false;
            }

            return pi;
        }

        static void MainMenu()
        {
            bool runMain = true;

            while (runMain)
            {
                parseInt parseint;
                Console.Clear();

                Console.WriteLine("0: Exit\n" +
                    "1: Options\n" +
                    "2: Display Vehicle/Vehicles\n" +
                    "3: Check In\n" +
                    "4: Check Out\n" +
                    "5: Search By");


                char input = Console.ReadLine()[0];
                string inputs = "";

                switch (input)
                {
                    case '0':
                        runMain = false;
                        break;
                    case '1':
                        MenuOptions();
                        break;
                    case '2':
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
                    case '3':
                        Console.WriteLine("0: Exit\n" +
                            "1: Bus\n" +
                            "2: Car\n" +
                            "3: Motorcycle\n" +
                            "4: Truck");

                        input = Console.ReadLine()[0];
                        Vehicle newVehicle = null;

                        //Set vehicle type based on vehicle type
                        switch (input)
                        {
                            case '0':
                                break;
                            case '1':
                                newVehicle = new Bus();
                                break;
                            case '2':
                                newVehicle = new Car();
                                break;
                            case '3':
                                newVehicle = new Motorcycle();
                                break;
                            case '4':
                                newVehicle = new Truck();
                                break;
                            default:
                                break;
                        }
                        
                        Console.WriteLine("Enter registration number: ");
                        inputs = Console.ReadLine();

                        if (garage.RegNrExists(inputs))
                        {
                            Console.WriteLine("Sorry, that seems to be an incorrect registration number.");
                            Console.ReadKey();
                            break;
                        }

                        newVehicle.RegNr = inputs;

                        Console.WriteLine("Enter brand: ");
                        inputs = Console.ReadLine();

                        newVehicle.Brand = inputs;

                        Console.WriteLine("Enter Model: ");
                        inputs = Console.ReadLine();

                        newVehicle.Model = inputs;

                        Console.WriteLine("Enter Color: ");
                        inputs = Console.ReadLine();

                        newVehicle.Color = inputs;

                        //Depending on type present additional options
                        switch (newVehicle.V)
                        {
                            case Vehicle.Vtype.Bus:
                                Console.WriteLine("Enter nr of seats: ");
                                inputs = Console.ReadLine();

                                
                                try
                                {
                                    Regex regex = new Regex(@"[^\d]");
                                    ((Bus)newVehicle).Seats = Int32.Parse(regex.Replace(inputs, ""));
                                }

                                Console.WriteLine("Enter size: ");
                                inputs = Console.ReadLine();
                                ((Bus)newVehicle).Size = inputs;

                                break;
                            case Vehicle.Vtype.Car:
                                Console.WriteLine("Enter production year as number: ");
                                inputs = Console.ReadLine();
                                try
                                {
                                    Regex regex = new Regex(@"[^\d]");
                                    ((Car)newVehicle).ProdYear = Int32.Parse(regex.Replace(inputs, ""));
                                }
                                catch (Exception e)
                                {
                                    ((Car)newVehicle).ProdYear = parseint.ret;
                                }                              
                                break;

                            case Vehicle.Vtype.Truck:
                                Console.WriteLine("Enter size: ");
                                inputs = Console.ReadLine();
                                ((Truck)newVehicle).Size = inputs;
                                break;
                            case Vehicle.Vtype.Motorcycle:
                                try
                                {
                                    Regex regex = new Regex(@"[^\d]");
                                    ((Motorcycle)newVehicle).Class = Int32.Parse(regex.Replace(inputs, ""));
                                }
                                catch (Exception e)
                                {
                                    ((Motorcycle)newVehicle).Class = parseint.ret;
                                }

                                break;
                            default:
                                break;
                        }
                        
                        garage.AddVehicle(newVehicle);
                        break;
                    case '4':
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
                    case '5':
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
                                Regex regex = new Regex(@"[^\d]");
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

        static void MenuOptions()
        {
            bool runOptions = true;

            while (runOptions)
            {
                Console.WriteLine("0: Exit\n" +
                    "1: Background Color\n" +
                    "2: Text Color\n");

                char input = Console.ReadLine()[0];

                switch (input)
                {
                    case '0':
                        runOptions = false;
                        break;
                    case '1':
                        Console.BackgroundColor = ConsoleColor.Blue;
                        break;
                    case '2':
                        Console.ForegroundColor = ConsoleColor.White;
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

            MainMenu();

        }

        /*
        static void SaveToFile(List<Vehicle> saveList)
        {
            foreach(Vehicle v in saveList)
            {
                System.IO.File.WriteAllText(@"C:\Users\elev\source\repos\Garage\data\testSave.txt", json);
            }
        }
        */
    }
}
