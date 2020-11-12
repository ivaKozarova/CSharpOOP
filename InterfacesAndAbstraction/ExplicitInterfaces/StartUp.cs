using ExplicitInterfaces.Contracts;
using ExplicitInterfaces.Models;
using System;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            while((input = Console.ReadLine())!= "End")
            {
                var inputArg = input.Split();
                Citizen citizen = new Citizen(inputArg[0], inputArg[1], int.Parse(inputArg[2]));
                IPerson person = citizen;
                person.GetName();
                IResident resident = citizen;
                resident.GetName();
            }
        }
    }
}
