using System;

namespace Operations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            MathOperations mo = new MathOperations();
            Console.WriteLine(mo.Add(3,2));
            Console.WriteLine(mo.Add(2.3,4.5, 4.5));
            Console.WriteLine(mo.Add(1.1m, 2.2m ,3.3m));
        }
    }
}
