using System;

namespace BoxData
{
    class Engine
    {
       public void Run()
        {
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            Box box = null;
            try
            {
                box = new Box(length, width, height);
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (box != null)
            {
                Print(box);
            }
                
        }
        private void Print(Box box)
        {
            Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
            Console.WriteLine($"Lateral Surface Area - { box.LateralSurfaceArea():f2}");
            Console.WriteLine($"Volume - {box.Volume():f2}");
        }

    }
}
