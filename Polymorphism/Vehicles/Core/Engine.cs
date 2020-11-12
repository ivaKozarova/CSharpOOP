using System;
using System.Linq;
using Vehicles.Models;

namespace Vehicles.Core
{
    class Engine
    {
        public Engine()
        {
        }
       public void Run()
        {                 
            Vehicle car = BulidVehicle();
            Vehicle truck = BulidVehicle();
            Vehicle bus = BulidVehicle();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split();
                try
                {
                    Process(car, truck,bus, line);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
                
        }

        private void Process(Vehicle car, Vehicle truck, Vehicle bus, string[] line)
        {
            var action = line[0];
            var type = line[1];
            var arg = double.Parse(line[2]);
            if(action == "Drive")
            {
                if(type == "Car")
                {
                    Console.WriteLine(car.Drive(arg));
                }
                else if(type == "Truck")
                {
                    Console.WriteLine(truck.Drive(arg));
                }
                else if(type == "Bus")
                {
                    Console.WriteLine(bus.Drive(arg));
                }
            }
            else if(action == "DriveEmpty")
            {
                Bus emptyBus = bus as Bus;
                Console.WriteLine(emptyBus.DriveEmpty(arg));
            }
            else if(action == "Refuel")
            {
                if (type == "Car")
                {
                    car.Refuel(arg);
                }
                else if (type == "Truck")
                {
                    truck.Refuel(arg);
                }
                else if(type == "Bus")
                {
                    bus.Refuel(arg);
                }
            }
        }

        private Vehicle BulidVehicle()
        {
            var line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            var type = line[0];
            var quantity = double.Parse(line[1]);
            var consumption = double.Parse(line[2]);
            var tankCapacity = double.Parse(line[3]);

            Vehicle vehicle = null;

            if(type == "Car")
            {
                vehicle = new Car(quantity, consumption, tankCapacity);
            }
            else if(type == "Truck")
            {
                vehicle = new Truck(quantity, consumption,tankCapacity);
            }
            else if(type == "Bus")
            {
                vehicle = new Bus(quantity, consumption, tankCapacity);
            }
            return vehicle;
        }
    }
}
