using System;
using WildFarm.Contracts;

namespace WildFarm.Models
{
    public abstract class Food : IFood
    {
        private int quantity;
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }
        public int Quantity
        {
            get { return this.quantity; }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                this.quantity = value;
            }

        }
    }
}
