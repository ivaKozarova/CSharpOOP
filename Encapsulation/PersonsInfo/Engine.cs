using System.Collections.Generic;
using System;

namespace PersonsInfo
{
    public class Engine
    {
        private readonly List<Person> people;
        public Engine()
        {
            this.people = new List<Person>();
        }

        public void Run()
        {
            var lines = int.Parse(Console.ReadLine());
            GetPeople(lines);
            var pecentage = decimal.Parse(Console.ReadLine());
            CalculateSalary(pecentage);
            PrintPeopleList();

        }

        private void PrintPeopleList()
        {
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }

        private void CalculateSalary(decimal pecentage)
        {
            people.ForEach(p => p.IncreaseSalary(pecentage));

        }

        private void GetPeople(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                var info = Console.ReadLine().Split();
                var firstName = info[0];
                var lastName = info[1];
                var age = int.Parse(info[2]);
                var salary = decimal.Parse(info[3]);
                Person person = null;
                try
                {
                    person = new Person(firstName, lastName, age, salary);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    continue;
                }
                people.Add(person);
            }
        }
    }
}
