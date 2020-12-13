using System;
using Bakery.Models.Drinks.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Models.Drinks
{
    public abstract class Drink : IDrink
    {
        private const int MIN_PORTION_VALUE = 1;

        private string name;
        private int portion;
        private decimal price;
        private string brand;

        public Drink(string name, int portion, decimal price, string brand)
        {
            this.Name = name;
            this.Portion = portion;
            this.Price = price;
            this.Brand = brand;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidName);
                }
                this.name = value;
            }
        }

        public int Portion
        {
            get { return this.portion; }
            private set
            {
                if (value <= MIN_PORTION_VALUE)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPortion);
                }
                this.portion = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }
                this.price = value;
            }
        }
        public string Brand
        {
            get { return this.brand; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBrand);
                }
                this.brand = value;
            }
        }
        public override string ToString()
        {
            var msg = $"{this.Name} {this.Brand} - {this.Portion}ml - {this.Price:f2}lv";
            return msg;
        }
    }
}
