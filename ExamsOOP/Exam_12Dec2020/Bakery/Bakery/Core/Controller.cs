using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Enums;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private readonly List<IBakedFood> foods;
        private readonly List<IDrink> drinks;
        private readonly List<ITable> tables;

        private decimal totalIncomes;
        public Controller()
        {
            this.foods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            if (Enum.TryParse(type, out DrinkType drinkType))
            {
                var drink = CreateDrink(drinkType, name, portion, brand);
                this.drinks.Add(drink);
                return String.Format(OutputMessages.DrinkAdded, name, brand);
            }
            return null;
        }
            public string AddFood(string type, string name, decimal price)
        {
            if (Enum.TryParse(type, out BakedFoodType bakedFoodType))
            {

                var food = CreateBakedFood(bakedFoodType, name, price);
                this.foods.Add(food);
                return String.Format(OutputMessages.FoodAdded,name, food.GetType().Name);
            }
            return null;
        }
        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (Enum.TryParse(type, out TableType tableType))
            {
                var table = CreateTable(tableType, tableNumber, capacity);
                this.tables.Add(table);
                return String.Format(OutputMessages.TableAdded, tableNumber);
            }
            return null;
        }
        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            var tables = this.tables.Where(t => t.IsReserved == false).ToList();

            foreach (var table in tables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            
            return $"Total income: {this.totalIncomes:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            var bill = table.GetBill();
            this.totalIncomes += bill;
            table.Clear();
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Table: {tableNumber}")
                   .AppendLine($"Bill: {bill:f2}");

            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            var drink = this.drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);
            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }
            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            var food = this.foods.FirstOrDefault(f => f.Name == foodName);
            if(food == null)
            {
                return $"No {foodName} in the menu";
            }
            table.OrderFood(food);
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            var table = this.tables.FirstOrDefault(t =>( t.IsReserved == false && t.Capacity >= numberOfPeople));
            if (table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            table.Reserve(numberOfPeople);
            return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";


        }
        private IBakedFood CreateBakedFood(BakedFoodType bakedFoodType, string name, decimal price)
        {
            IBakedFood food = null;
            switch (bakedFoodType)
            {
                case BakedFoodType.Bread:
                    food = new Bread(name, price);
                    break;
                case BakedFoodType.Cake:
                    food = new Cake(name, price);
                    break;
            }
            return food;
        }
        private IDrink CreateDrink(DrinkType drinkType, string name, int portion, string brand)
        {
            IDrink drink = null;
            switch (drinkType)
            {
                case DrinkType.Tea:
                    drink = new Tea(name, portion, brand);
                    break;
                case DrinkType.Water:
                    drink = new Water(name, portion, brand);
                    break;

            }
            return drink;
        }
        private ITable CreateTable(TableType tableType, int tableNumber, int capacity)
        {
            ITable table = null;
            switch (tableType)
            {
                case TableType.InsideTable:
                    table = new InsideTable(tableNumber, capacity);
                    break;
                case TableType.OutsideTable:
                    table = new OutsideTable(tableNumber, capacity);
                    break;
            }
            return table;
        }
    }
}
