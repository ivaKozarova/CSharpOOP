using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split();
            var urls = Console.ReadLine().Split();

            Smartphone smartphone = new Smartphone();
            StationaryPhone stationary = new StationaryPhone();

            foreach (var num in numbers)
            {
                if (num.Length == 7)
                {
                    Console.WriteLine(stationary.Calling(num));
                }
                else if (num.Length == 10)
                {
                    Console.WriteLine(smartphone.Calling(num));
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }
            foreach (var url in urls)
            {
                Console.WriteLine(smartphone.Browsing(url));
            }

        }
    }
}
