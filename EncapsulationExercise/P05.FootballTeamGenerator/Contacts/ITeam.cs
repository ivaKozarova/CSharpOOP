using System.Collections.Generic;
using P05.FootballTeamGenerator.Models;

namespace P05.FootballTeamGenerator.Contacts
{
    public interface ITeam
    {
        string Name { get; }
       // ICollection<Player> Players { get; }
    }
}
