using System;

namespace HotelReservation
{
    class Program
    {
        static void Main(string[] args)
        {
           var calc = new PriceCalculator();

            var input = Console.ReadLine().Split();
            var pricePerDay = decimal.Parse(input[0]);
            var days = int.Parse(input[1]);
            var season = Enum.Parse<Season>(input[2]);
            var discount = Discount.None;
            if (input.Length == 4)
            {
               discount = Enum.Parse<Discount>(input[3]);
            }
            

           var totalPrice=  calc.Calculate(pricePerDay, days, season, discount);
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
