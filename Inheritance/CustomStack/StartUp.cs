using System;
using System.Collections.Generic;

namespace CustomStack
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var stack = new StackOfStrings();
            Console.WriteLine(stack.IsEmpty());
            stack.Push("misho");
            stack.Push("gosho");
            stack.Push("somethig");
            Console.WriteLine(stack.Count);

            var values = new Stack<string>
            (new string[] { "newOne", "newTwo", "newThree" });
           
            stack.AddRange(values);
            Console.WriteLine(stack.Count);

            

        }
    }
}
