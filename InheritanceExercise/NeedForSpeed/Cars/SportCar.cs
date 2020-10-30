namespace NeedForSpeed
{
    class SportCar : Car
    {
        private const double DEFAULT_FUEL_CONSUMPTION = 10;
        public SportCar(int horsePower, double fuel)
           : base(horsePower, fuel)
        {
        }
        public override double FuelConsumption => DEFAULT_FUEL_CONSUMPTION;
        public override void Drive(double kilometers)
        {
            var fuelForDrive = this.FuelConsumption * kilometers;
            if (this.Fuel - fuelForDrive >= 0)
            {
                this.Fuel -= fuelForDrive;
            }
        }


    }
}
