using System;

namespace StudentSystem
{
    public class Engine
    {
        private StudentsData studentData;

        public Engine(StudentsData studentData)
        {
            this.studentData = studentData;
        }
        public void Process()
        {
            var end = false;
            while (!end)
            {
                var line = Console.ReadLine();
                var command = Command.Parse(line);
                var name = command.Name;
                var arguments = command.Arguments;
                switch (name)
                {
                    case "Create":
                        this.studentData.Add(arguments[0], int.Parse(arguments[1]), double.Parse(arguments[2]));
                        break;
                    case "Show":
                        var details = this.studentData.GetDetails(arguments[0]);
                        Console.WriteLine(details);
                        break;
                    case "Exit":
                        end = true;
                        break;
                }
            }
        }
    }
}
