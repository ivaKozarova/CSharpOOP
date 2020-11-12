using System;
using System.Collections.Generic;
using WildFarm.Factories;
using WildFarm.IO;
using WildFarm.IO.Contacts;
using WildFarm.Models;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly ICollection<Animal> animals;
        private IWritable writer;
        private IReadable reader;
        private FoodFactory foodFactory;
        private AnimalFactory animalFactory;
        public Engine()
        {
            this.animals = new List<Animal>();
            this.writer = new ConsoleWriter();
            this.reader = new ConsoleReader();
            this.animalFactory = new AnimalFactory();
            this.foodFactory = new FoodFactory();
        }

        public void Run()
        {
            string line;
            while((line = reader.ReadLine())!= "End")
            {
                var animalInfo = line.Split();
                var foodInfo = reader.ReadLine().Split();
                Animal animal = animalFactory.CreateAnimal(animalInfo);
                Food food = foodFactory.CreateFood(foodInfo);
                writer.WriteLine(animal.ProduceSound());
                try
                {            
                    animal.Feed(food);
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }
                animals.Add(animal);
            }

            foreach (var animal in this.animals)
            {
                writer.WriteLine(animal.ToString());
            }
        }
    }
}
