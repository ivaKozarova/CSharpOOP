using System;

using P05.FootballTeamGenerator.IO.Contracts;

namespace P05.FootballTeamGenerator.IO.Models
{
    public class ConsoleReader : IReadable
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
