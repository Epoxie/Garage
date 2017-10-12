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
        static bool isRunning = true;



        static void MainMenu()
        {
            bool runMain = true;

            while (runMain)
            {
                Console.Clear();

                Console.WriteLine("0: Exit\n" +
                    "1: Options\n" +
                    "2: Display Vehicle/Vehicles\n" +
                    "3: Check In\n" +
                    "4: Check Out\n" +
                    "5: Search Reg Number\n" +
                    "6: Search By");


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
                            Console.WriteLine(garage.SearchByRegNr(inputs).ElementAt(0));
                        }
                        //Return all info for a specific vehicle by reg number

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
                                newVehicle.v = Vehicle.Vtype.Bus;
                                break;
                            case '2':
                                newVehicle = new Car();
                                newVehicle.v = Vehicle.Vtype.Car;
                                break;
                            case '3':
                                newVehicle = new Motorcycle();
                                newVehicle.v = Vehicle.Vtype.Motorcycle;
                                break;
                            case '4':
                                newVehicle = new Truck();
                                newVehicle.v = Vehicle.Vtype.Truck;
                                break;
                            default:
                                break;
                        }
                        
                        Console.WriteLine("Enter registration number: ");
                        inputs = Console.ReadLine();

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
                        switch (newVehicle.v)
                        {
                            case Vehicle.Vtype.Bus:
                                Console.WriteLine("Enter nr of seats: ");
                                inputs = Console.ReadLine();

                                try
                                {
                                    ((Bus)newVehicle).Seats = int.Parse(inputs);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("The input was not a whole number! " +e);                                 
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
                                    ((Car)newVehicle).ProdYear = int.Parse(inputs);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("The input was not a whole number! " + e);
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
                                    ((Motorcycle)newVehicle).Class = int.Parse(inputs);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("The input was not a whole number! " + e);
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

                        Vehicle vehicleToRemove = garage.SearchByRegNr(inputs).ElementAt(0);

                        if (vehicleToRemove != null)
                        {
                            double time = DateTime.Now.Subtract(vehicleToRemove.ParkTime).TotalSeconds;
                            double price = pricePerSecond * time;

                            garage.RemoveVehicle(vehicleToRemove);

                            Console.WriteLine("Price for {0} seconds, is {1} kronor", time, price);
                            Console.ReadKey(false);
                        }

                        
                        break;
                    case '5':
                        Console.WriteLine("Enter registration number: ");
                        inputs = Console.ReadLine();
                        garage.SearchByRegNr(inputs);
                        break;
                    case '6':
                        Console.Clear();
                        List<Vehicle> tempVList;
                        Console.Write("Registration Number: ");
                        string tempRegNr = Console.ReadLine();
                        Console.Write("Model: ");
                        string tempModel = Console.ReadLine();
                        Console.Write("Color: ");
                        string tempColor = Console.ReadLine();
                        Console.Write("Brand: ");
                        string tempBrand = Console.ReadLine();
                        Console.WriteLine("Time of Parking? (y/n)");
                        string tempInput = Console.ReadLine();
                        try
                        {
                            if (tempInput[0] == 'y')
                            {
                                Regex regex = new Regex(@"[^\d]");
                                Console.Write("Time in year: ");
                                int tempYear = Int32.Parse(regex.Replace(Console.ReadLine(), ""));
                                Console.Write("Month: ");
                                int tempMonth = Int32.Parse(regex.Replace(Console.ReadLine(), ""));
                                Console.Write("Day: ");
                                int tempDay = Int32.Parse(regex.Replace(Console.ReadLine(), ""));
                                Console.Write("Hour: ");
                                int tempHour = Int32.Parse(regex.Replace(Console.ReadLine(), ""));
                                Console.Write("Minute: ");
                                int tempMinute = Int32.Parse(regex.Replace(Console.ReadLine(), ""));
                                Console.Write("Second: ");
                                int tempSecond = Int32.Parse(regex.Replace(Console.ReadLine(), ""));
                                tempVList = garage.SearchWithOptions(tempRegNr, tempModel, tempColor, tempBrand, new DateTime(tempYear, tempMonth, tempDay, tempHour, tempMinute, tempSecond));
                            }
                            else
                                tempVList = garage.SearchWithOptions(tempRegNr, tempModel, tempColor, tempBrand);
                        } catch
                        {
                            tempVList = garage.SearchWithOptions(tempRegNr, tempModel, tempColor, tempBrand);
                        }
                        foreach (Vehicle v in tempVList)
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
    }
}
