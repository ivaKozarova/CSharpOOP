using ExplicitInterfaces.Contracts;

namespace ExplicitInterfaces.Models
{
    public class Citizen : IPerson, IResident
    {
        public Citizen(string name, string country, int age )
        {
            this.Name = name;
            this.Country = country;
            this.Age = age;
        }
        public string Name { get; }

        public int Age { get; }

        public string Country { get; }

       void IPerson.GetName() => System.Console.WriteLine(this.Name);
        void IResident.GetName() => System.Console.WriteLine($"Mr/Ms/Mrs {this.Name}");


    }
}
