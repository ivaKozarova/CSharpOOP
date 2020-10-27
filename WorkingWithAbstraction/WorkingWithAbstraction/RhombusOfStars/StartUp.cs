using System;

namespace RhombusOfStars
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <=  n; i++)
            {
                PrintRow(i, n);
            }
            for (int i = n-1; i >= 1; i--)
            {
                PrintRow(i, n);
            }
        }

        private static void PrintRow(int i, int n)
        {
            Console.Write(new string(' ', n - i));
            for (int j = 1; j < i; j++)
            {
                Console.Write("* ");
            }
            Console.WriteLine("*");
        }
    }
}
