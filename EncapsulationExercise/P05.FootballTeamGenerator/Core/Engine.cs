using System;
using System.Linq;

using P05.FootballTeamGenerator.Models;
using P05.FootballTeamGenerator.IO.Models;
using P05.FootballTeamGenerator.Factories;
using P05.FootballTeamGenerator.IO.Contracts;
using P05.FootballTeamGenerator.Common.Exceptions;
using System.Collections.Generic;

namespace P05.FootballTeamGenerator.Core
{
    public class Engine : IEngine
    {
        private IReadable reader;
        private IWritable writer;
        private PlayerFactory playerFactory;
        private readonly List<Team> teams;
        public Engine()
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
            this.playerFactory = new PlayerFactory();
            this.teams = new List<Team>();
            
        }

        public void Run()
        {
            string line;
            
            while ((line = reader.ReadLine()) != "END")
            {
                var teamInfo = line.Split(';',StringSplitOptions.RemoveEmptyEntries);

                var command = teamInfo[0];
                var teamName = teamInfo[1];
                try
                {
                    if (command == "Team")
                    {
                        Team team = new Team(teamName);
                        teams.Add(team);
                    }
                    else if (command == "Add")
                    {
                        var teamtoAdd = teams.FirstOrDefault(t => t.Name == teamName);
                        if (teamtoAdd == null)
                        {
                            throw new ArgumentException(String.Format(ExceptionMessages.InvalidTeamExc, teamName));
                        }
                        var playerName = teamInfo[2];
                        var stats = teamInfo.Skip(3).Select(int.Parse).ToArray();
                        Player player = playerFactory.CreatePlayer(playerName, stats);
                        teamtoAdd.Add(player);
                    }
                    else if(command == "Remove")
                    {
                        var currTeam = teams.FirstOrDefault(t => t.Name == teamName);
                        if(currTeam == null)
                        {
                            throw new ArgumentException(String.Format(ExceptionMessages.InvalidTeamExc, teamName));
                        }
                        var playerName = teamInfo[2];
                        currTeam.Remove(playerName);
                    }
                    else if(command == "Rating")
                    {
                        var currTeam = teams.FirstOrDefault(t => t.Name == teamName);
                        if (currTeam == null)
                        {
                            throw new ArgumentException(String.Format(ExceptionMessages.InvalidTeamExc, teamName));
                        }
                         writer.WriteLine($"{currTeam.Name} - {currTeam.Rating}");
                    }
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }
                
            }

        }
    }
}
