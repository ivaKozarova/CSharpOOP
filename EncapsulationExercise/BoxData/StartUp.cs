using System;

namespace BoxData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var length = int.Parse(Console.ReadLine());
            var width = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());

            Box box = new Box(length, width, height);
            Console.WriteLine(box.SurfaceArea());
            Console.WriteLine(box.LateralSurfaceArea());
            Console.WriteLine(box.Volume());
        }
    }
}
