using System;

namespace StudentSystem
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var studentDta = new StudentsData();
            var engine = new Engine(studentDta);
            engine.Process();

        }
    }
}
