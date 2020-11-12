using System;
using Vehicles.Contracts;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;
        public Vehicle(double quantity, double consumption, double tankCapacity )
        {            
            this.FuelConsumption = consumption;
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = quantity;
        }
        public double FuelQuantity 
        {
            get => this.fuelQuantity; 
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
            
        }

        public virtual double FuelConsumption { get; private set; }

        public double TankCapacity { get; private set; }

        public virtual string Drive(double distance)
        {
            
                var fuelNeeded = this.FuelConsumption * distance;
                if (this.FuelQuantity < fuelNeeded)
                {
                    string notEnoughFuelExc = $"{this.GetType().Name} needs refueling";
                    throw new InvalidOperationException(notEnoughFuelExc);
                }
                this.FuelQuantity -= fuelNeeded;
                return $"{this.GetType().Name} travelled {distance} km";
            
        }
       

        public virtual void Refuel(double liters)
        {
           if(liters <= 0)
            { 
                throw new InvalidOperationException("Fuel must be a positive number");
            }
           else if(liters > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");
            }
            this.FuelQuantity += liters;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
