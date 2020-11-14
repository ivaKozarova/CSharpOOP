using P05.FootballTeamGenerator.Models;

namespace P05.FootballTeamGenerator.Factories
{
   public  class PlayerFactory
    {
        public Player CreatePlayer(string name, int[] statsArg)
        {
            var endurance = statsArg[0];
            var sprint = statsArg[1];
            var dribble = statsArg[2];
            var passing = statsArg[3];
            var shooting = statsArg[4];

            Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);
            Player player = new Player(name, stats);
            return player;
        }
    }
}
