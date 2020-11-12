using System;

namespace Animals
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            Animal dog = new Dog("Sharo", "kokal");
            Console.WriteLine(dog.ExplainSelf());
            Dog dog2 = new Dog("Bella", "drobcheta");

            Cat cat = new Cat("myro", "fish");
            Console.WriteLine(dog2.ExplainSelf());
            Console.WriteLine(cat.ExplainSelf());

        }
    }
}
