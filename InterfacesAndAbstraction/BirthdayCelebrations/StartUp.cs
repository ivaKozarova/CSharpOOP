using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            var birthdatesList = new List<IBirthdate>();
            while((input = Console.ReadLine())!= "End")
            {
                var inputArgs = input.Split();
                var kind = inputArgs[0];
                switch(kind)
                {
                    case "Citizen":
                        var citizenName = inputArgs[1];
                        var age = int.Parse(inputArgs[2]);
                        var id = inputArgs[3];
                        var birthDate = inputArgs[4];
                        IBirthdate citizen = new Citizen(citizenName, age, id, birthDate);
                        birthdatesList.Add(citizen);
                        break;
                    case "Pet":
                        var petName = inputArgs[1];
                        var petBirthDate = inputArgs[2];
                        IBirthdate pet = new Pet(petName, petBirthDate);
                        birthdatesList.Add(pet);
                        break;
                }
            }

            string birthdateSearched = Console.ReadLine();
            foreach (var el in birthdatesList)
            {
                if(el.Birthdate.EndsWith(birthdateSearched))
                {
                    Console.WriteLine(el.Birthdate);
                }
            }
        }
    }
}
