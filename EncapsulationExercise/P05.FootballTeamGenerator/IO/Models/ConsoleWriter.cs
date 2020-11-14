using System;

using P05.FootballTeamGenerator.IO.Contracts;

namespace P05.FootballTeamGenerator.IO.Models
{
    public class ConsoleWriter : IWritable
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
