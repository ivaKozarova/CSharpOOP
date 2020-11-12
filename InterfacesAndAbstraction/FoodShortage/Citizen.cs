namespace FoodShortage
{
    public class Citizen : Person, IBuyer
    {
        public Citizen(string name, int age, string id, string birthDate)
           
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDate = birthDate;
        }
        
        public string Id { get; private set; }
        public string BirthDate { get; private set; }

      
       
        public override void BuyFood()
        {
            this.Food += 10;
        }
    }
}
