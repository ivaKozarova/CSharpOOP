using MilitaryElite.Interfaces;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class StartUp
    {
       
        static void Main(string[] args)
        {
            HashSet<Private> allPrivates = new HashSet<Private>();
            HashSet<Soldier> soldiers = new HashSet<Soldier>();

            string input;
            while((input = Console.ReadLine()) != "End")
            {
                var inputArgs = input.Split();

                var type = inputArgs[0];

                var id = int.Parse(inputArgs[1]);
                var firstName = inputArgs[2];
                var lastName = inputArgs[3];
             

                switch (type)
                {
                    case "Private":
                        Private currPrivate = CreatePrivate(id, firstName, lastName, inputArgs[4]);
                        allPrivates.Add(currPrivate);
                        soldiers.Add(currPrivate);
                        
                        break;
                    case "LieutenantGeneral":
                        var currLeutenant = CreateLeutenantGen(allPrivates, inputArgs, id, firstName, lastName);
                        soldiers.Add(currLeutenant);
                        break;
                    case "Engineer":
                        var engineer = CreateEngineer(inputArgs, id, firstName, lastName);
                        if(engineer != null)
                        {
                            soldiers.Add(engineer);
                        }
                        break;
                    case "Commando":
                        var commando = CreateCommando(inputArgs, id, firstName, lastName);
                        if (commando != null)
                        {
                            soldiers.Add(commando);
                        }
                        break;
                    case "Spy":
                        var spy = CreateSpy(id, firstName, lastName, inputArgs[4]);
                        soldiers.Add(spy);
                        break;
                }
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }

        }

        private static Spy CreateSpy(int id, string firstName, string lastName, string codeArg)
        {
            var codeNumber = int.Parse(codeArg);
            Spy spy = new Spy(id, firstName, lastName, codeNumber);
            return spy;
        }

        private static Commando CreateCommando(string[] inputArgs, int id, string firstName, string lastName)
        {
            if (VerifyCorps(inputArgs, out Corps corps))
            {
                var salary = decimal.Parse(inputArgs[4]);
                var missionsArgs = inputArgs.Skip(6).ToArray();
                Commando commando = new Commando(id, firstName, lastName, salary, corps);
                for (int i = 0; i < missionsArgs.Length; i += 2)
                {
                    var codeName = missionsArgs[i];
                    var state = missionsArgs[i + 1];
                    if (state == "inProgress" || state == "Finished")
                    {
                        Mission mission = new Mission(codeName, state);
                        commando.Missions.Add(mission);
                    }
                }
                return commando;
            }
            return null;
        }

        private static Engineer CreateEngineer(string[] inputArgs, int id, string firstName, string lastName)
        {
            
            if (VerifyCorps(inputArgs, out Corps corps))
            {
                var salary = decimal.Parse(inputArgs[4]);
                var partsArgs = inputArgs.Skip(6).ToArray();
                Engineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                for (int i = 0; i < partsArgs.Length; i += 2)
                {
                    var partName = partsArgs[i];
                    var partHours = int.Parse(partsArgs[i + 1]);
                    Repair repair = new Repair(partName, partHours);
                    engineer.Repairs.Add(repair);
                }
                return engineer;
            }
            return null;
        }

        private static bool VerifyCorps(string[] inputArgs, out Corps corps)
        {
            return Enum.TryParse(inputArgs[5], out corps);
        }

        private static LeutenantGeneral CreateLeutenantGen(HashSet<Private> allPrivates, string[] inputArgs, int id, string firstName, string lastName)
        {
            var privateIds = inputArgs.Skip(5).Select(int.Parse).ToArray();
            LeutenantGeneral leutenant = new LeutenantGeneral(id, firstName, lastName, decimal.Parse(inputArgs[4]));
            foreach (var privId in privateIds)
            {
                var currPriv = allPrivates.First(p => p.Id == privId);
                leutenant.Privates.Add(currPriv);
                
            }
            return leutenant;
        }

        private static Private CreatePrivate(int id, string firstName, string lastName, string argsSalary)
        {
            var salary = decimal.Parse(argsSalary);
            Private priv = new Private(id, firstName, lastName, salary);
            return priv;
        
        }
    }
}
