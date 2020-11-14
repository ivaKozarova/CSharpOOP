using P05.FootballTeamGenerator.Models;

namespace P05.FootballTeamGenerator.Contacts
{
    public interface IPlayer
    {
        string Name { get; }
        Stats Stats { get; }
    }
}
