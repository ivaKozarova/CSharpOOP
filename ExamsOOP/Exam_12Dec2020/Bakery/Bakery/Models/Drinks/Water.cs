namespace Bakery.Models.Drinks
{
    public class Water : Drink
    {
        private const decimal WATER_PRICE = 1.5m;
        public Water(string name, int portion, string brand) 
            : base(name, portion, WATER_PRICE, brand)
        {
        }
    }
}
