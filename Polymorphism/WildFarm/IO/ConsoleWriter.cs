using System;
using WildFarm.IO.Contacts;

namespace WildFarm.IO
{
    class ConsoleWriter : IWritable
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
