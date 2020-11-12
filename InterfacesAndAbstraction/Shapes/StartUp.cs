using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var raduis = int.Parse(Console.ReadLine());
            Circle circle = new Circle(raduis);
            circle.Draw();

            var width = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());
            Rectangle rect = new Rectangle(width, height);

            rect.Draw();

        }
    }
}
