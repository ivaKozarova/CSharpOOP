namespace HotelReservation
{
    public class PriceCalculator
    {
        public decimal Calculate(decimal pricePerDay, int days, Season season, Discount discount = Discount.None)
        {
            var price = pricePerDay * days * (int)season;
            price -= (int)discount * price/ 100;
            return price;
        }

    }
}
