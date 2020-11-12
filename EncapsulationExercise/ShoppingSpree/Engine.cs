using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Engine
    {
        private List<Person> people;
        private List<Product> products;


        public Engine()
        {
            this.people = new List<Person>();
            this.products = new List<Product>();

        }

        public void Run()
        {
            AddPeople();
            AddProducts();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var inputArg = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                var name = inputArg[0];
                var product = inputArg[1];
        
                try
                {
                    var currPerson = this.people.First(p => p.Name == name);
                    var currProduct = this.products.First(p => p.Name == product);
                    currPerson.BuyProduct(currProduct);
                    Console.WriteLine($"{currPerson.Name} bought {currProduct.Name}");
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
            Print();
        }

        private void Print()
        {
            foreach (var person in this.people)
            {
                Console.WriteLine(person);
            }
        }

        private void AddPeople()
        {
            var firstLine = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < firstLine.Length; i++)
            {
                var info = firstLine[i].Split("=",StringSplitOptions.RemoveEmptyEntries);
                var name = info[0];
                var money = decimal.Parse(info[1]);
                Person person = new Person(name, money);
                this.people.Add(person);
            }
        }
        private void AddProducts()
        {
            var secondLine = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < secondLine.Length; i++)
            {
                var productsInfo = secondLine[i].Split("=",StringSplitOptions.RemoveEmptyEntries);
                var name = productsInfo[0];
                var cost = decimal.Parse(productsInfo[1]);
                Product product = new Product(name, cost);
                this.products.Add(product);

            }
        }
        
    }
}
