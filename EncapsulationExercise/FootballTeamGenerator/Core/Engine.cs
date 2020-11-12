using FootballTeamGenerator.Common;
using FootballTeamGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator.Core
{
    public class Engine
    {
        private readonly ICollection<Team> teams;
        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
               
                try
                {
                    var cmdArg = command.Split(';').ToArray();
                    var cmdType = cmdArg[0];
                    var nameOfTeam = cmdArg[1];
                    if (cmdType == "Team")
                    {
                        this.CreateTeam(nameOfTeam);
                    }
                    else if (cmdType == "Add")
                    {
                        this.ValidateTeamExist(nameOfTeam);
                        var args = cmdArg.Skip(1).ToArray();
                        this.AddPlayerToTeam(args);
                    }
                    else if (cmdType == "Remove")
                    {
                        this.ValidateTeamExist(nameOfTeam);
                        var playerName = cmdArg[2];
                        this.RemovePlayer(nameOfTeam, playerName);

                    }
                    else if (cmdType == "Rating")
                    {
                        this.ValidateTeamExist(nameOfTeam);
                        Team currTeam = teams.First(t => t.Name == nameOfTeam);

                        Console.WriteLine(currTeam);

                    }
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }

        private void ValidateTeamExist(string nameOfTeam)
        {
            
            if (!this.teams.Any(t=>t.Name == nameOfTeam))
            {
                throw new ArgumentException(string.Format(GlobalConstants.MissingTeamExcMsg, nameOfTeam));
            }
          
        }

        private void RemovePlayer(string nameOfTeam, string playerName)
        {
            Team currTeam = this.teams.First(t => t.Name == nameOfTeam);
            currTeam.RemovePlayer(playerName);

        }

        private void CreateTeam(string nameOfTeam)
        {
            Team team = new Team(nameOfTeam);
            this.teams.Add(team);
        }
        private void AddPlayerToTeam(string[] args)
        {
            var teamName = args[0];
            var playerName = args[1];
            var stats = args.Skip(2).Select(int.Parse).ToArray();

            Team currentTeam = teams.First(t => t.Name == teamName);
            Player player = CreatePlayer(playerName, stats);
            currentTeam.AddPlayer(player);
        }

        private Player CreatePlayer(string playerName, int[] statsArgs)
        {
            var endurance = statsArgs[0];
            var sprint = statsArgs[1];
            var dribble = statsArgs[2];
            var passing = statsArgs[3];
            var shooting = statsArgs[4];

            Player player = new Player(playerName, new Stats(endurance, sprint, dribble, passing, shooting));
            return player;
        }
    }
}
