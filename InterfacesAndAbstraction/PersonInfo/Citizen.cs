using System.Reflection.Metadata.Ecma335;

namespace PersonInfo
{
    public class Citizen : IPerson,IIdentifiable , IBirthable
    {
        private string name;
        private int age;
        private string id;
        private string birthday;
        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthday;
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                this.age = value;
            }
        }

        public string Id { get; private set; }
    

        public string Birthdate { get; private set; }
    }
}
