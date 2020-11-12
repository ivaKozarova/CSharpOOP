namespace BirthdayCelebrations
{
    public class Pet : IBirthdate
    {
        public Pet(string name, string birthDate)
        {
            this.Name = name;
            this.Birthdate = birthDate;
        }
        public string Name { get; private set; }

        public string Birthdate { get; private set; }
    }
}
