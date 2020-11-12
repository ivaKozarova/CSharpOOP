namespace Vehicles.Models
{
    class Car : Vehicle
    {
        private const double EXTRA_CONSUMPTION = 0.9;
        
        public Car(double quantity, double consumption, double tankCapacity) 
            : base(quantity, consumption, tankCapacity)
        {
        }
        public override double FuelConsumption => base.FuelConsumption + EXTRA_CONSUMPTION;
    }
}
