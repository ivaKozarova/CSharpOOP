using System;

namespace Person
{
   public class Person
    {
        private const int MIN_AGE_VALUE = 0;
        private string name;
        private int age;
        public Person(string name , int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name
        {
            get { return this.name; }
           private set { this.name = value; }
        }
          public virtual int Age
        {
           get
            { return this.age; }
            protected set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Invalid age");

                }
                this.age = value; 
            }
        }
        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}".ToString();
        }
    }
}
