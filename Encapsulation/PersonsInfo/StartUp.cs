using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var people = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                var info = Console.ReadLine().Split();
                var salary = decimal.Parse(info[3]);
                var person = new Person(info[0], info[1], int.Parse(info[2]),salary);
                people.Add(person);
            }
            var pecentage = decimal.Parse(Console.ReadLine());

            //people = people.OrderBy(p => p.FirstName)
            //              .ThenBy(p => p.Age).ToList();

            people.ForEach(p => p.IncreaseSalary(pecentage));
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }

        }
    }
}
