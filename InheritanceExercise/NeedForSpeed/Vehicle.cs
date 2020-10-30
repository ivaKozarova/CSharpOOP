namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DEFAULT_FUEL_CONSUMPTION = 1.25;
        public Vehicle(int horsePower, double fuel)
        {
            this.Fuel = fuel;
            this.HorsePower = horsePower;
            
        }
        public virtual double FuelConsumption { get; set; } = DEFAULT_FUEL_CONSUMPTION;
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual void Drive (double kilometers)
        {
            
            var fuelForDrive = this.FuelConsumption * kilometers;
            if(this.Fuel - fuelForDrive >=0 )
            {
                this.Fuel -= fuelForDrive;
            }
        }


    }
}
