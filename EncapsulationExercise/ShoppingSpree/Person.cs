using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Person
    {
        private const decimal MIN_MONEY = 0;
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }
        public string Name
        {
            get { return this.name; }
           private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }
        public decimal Money 
        {
            get { return this.money; }
           private set
            {
                if(value < MIN_MONEY)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }
        public IReadOnlyCollection<Product> Bag
        {
            get { return this.bag.AsReadOnly(); }
        }

        public void BuyProduct(Product product)
        {
            if(this.Money < product.Cost)
            {
                throw new InvalidOperationException(string.Format("{0} can't afford {1}", this.Name, product.Name));
            }
            this.bag.Add(product);
            this.Money -= product.Cost;
        }
        public override string ToString()
        {
            var productsOutput = this.bag.Count > 0 ?
                string.Join(", ", this.Bag) : "Nothing bought";
            return $"{this.Name} - {productsOutput}";
        }

    }
}
