namespace FoodShortage
{
    public abstract class  Person : IBuyer
    {
        public Person()
        {

        }
        public string Name { get; set; }
        public int Age { get; set; }

        public int Food { get; set; }

        public abstract void BuyFood();
       
    }
}
