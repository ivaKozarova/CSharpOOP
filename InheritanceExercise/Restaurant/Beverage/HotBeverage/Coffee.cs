namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double CoffeeMilliliters = 50;
        private const decimal CoffeePrice = 3.50m;
        public Coffee(string name,  double coffeine)
            : base(name, CoffeePrice, CoffeeMilliliters)
        {
            this.Caffeine = coffeine;
        }
        public double Caffeine { get; set; }
    }
}