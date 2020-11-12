using System;

namespace Vehicles.Models
{
    class Truck : Vehicle
    {
        private const double EXTRA_CONSUM = 1.6;
        private const double DECREASE_LITERS = 0.95;
        public Truck(double quantity, double consumption, double tankCapacity)
            : base(quantity, consumption, tankCapacity)
        {            
        }
        public override double FuelConsumption => base.FuelConsumption + EXTRA_CONSUM;
        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new InvalidOperationException("Fuel must be a positive number");
            }
            else if (liters > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");
            }
            this.FuelQuantity += liters* DECREASE_LITERS;
        }

    }
}
