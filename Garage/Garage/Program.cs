using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    class Program
    {
        static Garage garage = new Garage();

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

                        foreach (var vehicle in garage.GetAllVehicles())
                        {
                            vehicle.ToString();
                        }

                        //Return all info for a specific vehicle by reg number
                        break;
                    case '3':
                        break;
                    case '4':
                        break;
                    case '5':
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

        static void Main(string[] args)
        {

            MainMenu();

        }
    }
}
