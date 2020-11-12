using System;
using System.Linq;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            var all = new List<IId>();

            while ((input = Console.ReadLine()) != "End")
            {
                var inputArg = input.Split().ToArray();
                if (inputArg.Length == 2)
                {
                    var model = inputArg[0];
                    var id = inputArg[1];
                    IId robot = new Robot(model, id);
                    all.Add(robot);
                }

                else if (inputArg.Length == 3)
                {
                    var name = inputArg[0];
                    var age = int.Parse(inputArg[1]);
                    var id = inputArg[2];
                    IId citizen = new Citizen(name, age, id);
                    all.Add(citizen);
                }
            }
            var fakeIdLastDigits = Console.ReadLine();

            foreach (var el in all)
            {
               
                if(el.Id.EndsWith(fakeIdLastDigits))
                {
                    Console.WriteLine(el.Id);
                }
             
            }
        }
    }
}


     