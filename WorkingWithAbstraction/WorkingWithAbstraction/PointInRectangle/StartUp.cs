using System;
using System.Linq;

namespace PointInRectangle
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var rectangleCoord = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Point topLeft = new Point(rectangleCoord[0], rectangleCoord[3]);
            Point bottomRight = new Point(rectangleCoord[2], rectangleCoord[1]);
            Rectangle rectangle = new Rectangle(topLeft, bottomRight);
            
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var pointCoord = Console.ReadLine().Split().Select(int.Parse).ToArray();
                Point point = new Point(pointCoord[0], pointCoord[1]);
                Console.WriteLine(rectangle.Contains(point));
                
            }

            
        }
    }
}
