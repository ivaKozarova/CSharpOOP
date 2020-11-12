using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var list = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split();
                var name = line[0];
                var age = int.Parse(line[1]);
                if(line.Length == 3)
                {
                    var group = line[2];
                    Person rebel = new Rebel(name, age, group);
                    list.Add(rebel);
                }
                else if(line.Length == 4)
                {
                    var id = line[2];
                    var birthDate = line[3];
                    var citizen = new Citizen(name, age, id, birthDate);
                    list.Add(citizen);
                }
            }

            string input;
            
            while((input = Console.ReadLine()) != "End")
            {
                var currentPerson = list.FirstOrDefault(p=>p.Name == input);
                if(currentPerson != null)
                {
                    currentPerson.BuyFood();
                }
            }
            int totalFood = list.Sum(p => p.Food);
            Console.WriteLine(totalFood);
        }
    }
}
