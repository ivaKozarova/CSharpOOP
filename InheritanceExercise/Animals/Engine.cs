using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class Engine
    {
        private const string END_OF_INPUT = "Beast!";
        private readonly List<Animal> animals;
        public Engine()
        {
            this.animals = new List<Animal>();
        }
        private void Print()
        {
            foreach (Animal animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }

        public void Run()
        {
            string type;
            while ((type = Console.ReadLine()) != END_OF_INPUT)
            {                
                var animalArgs = Console.ReadLine().Split().ToArray();
                Animal animal;
                try
                {
                    animal = GetAnimal(type, animalArgs);
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Invalid input!");
                    continue;
                }
               
                this.animals.Add(animal);
               
            }
             Print();
        }

        private Animal GetAnimal(string type, string[] animalArgs)
        {
            Animal animal = null;
            var name = animalArgs[0];
            var age = int.Parse(animalArgs[1]);
            string gender = null;
            if (animalArgs.Length >= 3)
            {
                gender = animalArgs[2];
            }
            if (type == "Dog")
            {
                animal = new Dog(name, age, gender);
            }
            else if (type == "Cat")
            {
                animal = new Cat(name, age, gender);
            }
            else if (type == "Frog")
            {
                animal = new Frog(name, age, gender);
            }
            else if (type == "Kittens")
            {
                animal = new Kitten(name, age);
            }
            else if (type == "Tomcat")
            {
                animal = new Tomcat(name, age);
            }
            else
            {
                throw new ArgumentException("Invalid input!");
            }

            return animal;
        }
    }
}
