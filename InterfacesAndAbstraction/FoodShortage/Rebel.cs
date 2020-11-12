namespace FoodShortage
{
    public class Rebel : Person, IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }
        public string Group { get; private set; }
               
        public override void BuyFood()
        {
            this.Food += 5;
        }
    }
}
