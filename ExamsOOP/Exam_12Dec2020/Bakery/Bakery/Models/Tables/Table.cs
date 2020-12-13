using System;
using System.Linq;
using System.Collections.Generic;

using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private const int MIN_TABLE_CAPACITY = 0;
        private const int MIN_PEOPLE = 1;

        private readonly List<IBakedFood> foods;
        private readonly List<IDrink> drinks;
        private int capacity;
        private int numberOfPeople;
        
        public Table()
        {
            this.foods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
        }
        public Table(int tableNumber, int capacity, decimal pricePerPerson)
            :this()
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
        }
        public IReadOnlyCollection<IBakedFood> Foods => this.foods.AsReadOnly();
        public IReadOnlyCollection<IDrink> Drinks => this.drinks.AsReadOnly();

        public int TableNumber { get; }

        public int Capacity
        {
            get { return this.capacity; }
            private set
            {
                if(value < MIN_TABLE_CAPACITY)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get { return this.numberOfPeople; }
            private set
            {
                if(value < MIN_PEOPLE)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price => CalculatePrice();

        private decimal CalculatePrice()
        {
            return this.PricePerPerson * numberOfPeople;
        }

        public void Clear()
        {
            this.drinks.Clear();
            this.foods.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            var bill = this.Price + this.foods.Sum(f => f.Price) + this.drinks.Sum(d=>d.Price);
            return bill;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb
           .AppendLine($"Table: {this.TableNumber}")
           .AppendLine($"Type: {this.GetType().Name}")
           .AppendLine($"Capacity: {this.Capacity}")
           .AppendLine($"Price per Person: {this.PricePerPerson:f2}");

            return sb.ToString().TrimEnd();

        }


        public void OrderDrink(IDrink drink)
        {
            this.drinks.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            this.foods.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.numberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }
    }
}
