using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Garage
{
    class Program
    {
        static Garage garage = new Garage();
        static ConsoleKey key;
        static int cRow = 0;
        static int cCol = 0;

        static bool isRunning = true;

        static void MainMenu()
        {
            bool runMain = true;

            while (runMain)
            {

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
                            Console.WriteLine(garage.SearchByRegnr(inputs).ElementAt(0));
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

                        //Depending on type present additional options
                        switch (newVehicle.v)
                        {
                            case Vehicle.Vtype.Bus:
                                break;
                            case Vehicle.Vtype.Car:
                                break;
                            case Vehicle.Vtype.Truck:
                                break;
                            case Vehicle.Vtype.Motorcycle:
                                break;
                            default:
                                break;
                        }
                        
                        garage.AddVehicle(newVehicle);
                        break;
                    case '4':
                        break;
                    case '5':
                        inputs = Console.ReadLine();
                        garage.SearchByRegnr(inputs);
                        break;
                    case '6':
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

        static void KeyInput()
        {
            
            while (true)
            {
                key = Console.ReadKey().Key;

                switch (key)
                {

                    case ConsoleKey.Enter:
                        break;
                    case ConsoleKey.Escape:
                        break;
                    case ConsoleKey.UpArrow:
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        cRow--;
                        Console.SetCursorPosition(cCol, cRow);
                        string buffer = Console.Out.NewLine;
                        Console.WriteLine(buffer);
                        break;
                    case ConsoleKey.DownArrow:
                        cRow++;
                        Console.SetCursorPosition(cCol, cRow);
                        break;
                    default:
                        break;
                }
            }
            
        }

        static void Main(string[] args)
        {
            //Thread thread = new Thread(KeyInput);
            //thread.Start();
            MainMenu();

        }
    }
}
