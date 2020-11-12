using System;
using WildFarm.IO.Contacts;

namespace WildFarm.IO
{
    public class ConsoleReader : IReadable
    {
        public string ReadLine()
        {
            return Console.ReadLine();

        }
    }
}
