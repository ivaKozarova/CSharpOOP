using System.Collections.Generic;

namespace StudentSystem
{
    public class StudentsData
    {
        public Dictionary<string, Student> Students { get; } = new Dictionary<string, Student>();
        public void Add(string name, int age, double grade)
        {
            var student = new Student(name, age, grade);
            if (!this.Students.ContainsKey(name))
            {
                this.Students[name] = student;
            }
        }

        public string GetDetails(string name)
        {
            if (!this.Students.ContainsKey(name))
            {
                return null;
            }

            var student = this.Students[name];
            var details = $"{student.Name} is {student.Age} years old.";

            if (student.Grade >= 5.00)
            {
                details += " Excellent student.";
            }
            else if (student.Grade < 5.00 && student.Grade >= 3.50)
            {
                details += " Average student.";
            }
            else
            {
                details += " Very nice person.";
            }
            return details;
        }
        
    }

}
