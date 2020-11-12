using System;
using Raiding.IO.Contracts;

namespace Raiding.IO
{
    class ConsoleReader : IReadable
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
