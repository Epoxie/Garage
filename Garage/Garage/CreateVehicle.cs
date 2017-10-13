using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Garage
{
    class CreateVehicle
    {

        //Struct for parsing input, so we dont need try/catch everywhere
        public struct parseInt
        {
            public int ret;
            public bool success;
        };

        //Method for parsing input, returning a parseint struct
        public static parseInt ParseInputToInt(string input)
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



        public void FinalizeCar(Garage garage)
        {
            Regex regex = new Regex(@"[^\d]");
            parseInt parseint;
            char input = ' ';
            string inputs = "";

            Console.WriteLine("0: Exit\n" +
                "1: Bus\n" +
                "2: Car\n" +
                "3: Motorcycle\n" +
                "4: Truck");
            Vehicle newVehicle = null;

            //Set vehicle type based on vehicle type

                try
                {
                    input = Console.ReadLine()[0];
                }
                catch
                {
                    input = ' ';
                }

                switch (input)
                {
                    case '0':
                        break;
                    case '1':
                        newVehicle = new Bus();
                        newVehicle.V = Vehicle.Vtype.Bus;
                        break;
                    case '2':
                        newVehicle = new Car();
                        newVehicle.V = Vehicle.Vtype.Car;
                        break;
                    case '3':
                        newVehicle = new Motorcycle();
                        newVehicle.V = Vehicle.Vtype.Motorcycle;
                        break;
                    case '4':
                        newVehicle = new Truck();
                        newVehicle.V = Vehicle.Vtype.Truck;
                        break;
                    default:
                        Console.WriteLine("You have to choose a vehicle type");
                        Console.ReadKey(false);
                        return;
                }
            


            Console.WriteLine("Enter registration number: ");
            inputs = Console.ReadLine();

            if (garage.RegNrExists(inputs))
            {
                Console.WriteLine("Sorry, that seems to be an incorrect registration number.");
                Console.ReadKey();
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

                    parseint = ParseInputToInt(regex.Replace(inputs, ""));

                    if (parseint.success)
                    {
                        ((Bus)newVehicle).Seats = parseint.ret;
                    }


                    Console.WriteLine("Enter size: ");
                    inputs = Console.ReadLine();


                    ((Bus)newVehicle).Size = inputs;
                    break;

                case Vehicle.Vtype.Car:
                    Console.WriteLine("Enter production year as number: ");
                    inputs = Console.ReadLine();


                    regex = new Regex(@"[^\d]");
                    parseint = ParseInputToInt(regex.Replace(inputs, ""));

                    if (parseint.success)
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

                    parseint = ParseInputToInt(regex.Replace(inputs, ""));

                    if (parseint.success)
                    {
                        ((Motorcycle)newVehicle).Class = parseint.ret;
                    }

                    break;
                default:
                    break;
            }

            if (newVehicle != null)
            {
                garage.AddVehicle(newVehicle);
                Console.WriteLine(newVehicle.ToString() + "\nwas successfully added!");
                Console.WriteLine("Press any key to acknowledge");
                Console.ReadKey();
            }

        }
    }
}
