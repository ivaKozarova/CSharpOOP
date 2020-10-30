using System;
using System.Collections.Generic;

namespace CustomRandomList
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var randomList = new RandomList() { "Pesho", "Gosho", "Mario", "krasi" };
            randomList.Add("abds");
            Console.WriteLine(randomList.Count);
            Console.WriteLine(randomList.RandomString());
            Console.WriteLine(randomList.Count);
        }
    }
}
