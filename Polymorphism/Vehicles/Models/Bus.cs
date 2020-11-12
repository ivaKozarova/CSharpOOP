using System;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double EXTRA_CONSUM = 1.4;
        public Bus(double quantity, double consumption, double tankCapacity)
            : base(quantity, consumption, tankCapacity)
        {
        }
        public override double FuelConsumption => base.FuelConsumption + EXTRA_CONSUM;
       
        public string DriveEmpty(double distance)
        {
            var fuelNeeded = (this.FuelConsumption - EXTRA_CONSUM) * distance;
            if (this.FuelQuantity < fuelNeeded)
            {
                throw new InvalidOperationException($"{ this.GetType().Name } needs refueling");
            }
            this.FuelQuantity -= fuelNeeded;
            return $"{this.GetType().Name} travelled {distance} km";
        }
    }
}