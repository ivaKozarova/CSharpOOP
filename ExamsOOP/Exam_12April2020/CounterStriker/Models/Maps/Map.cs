using System.Linq;
using System.Collections.Generic;

using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public Map()
        {
        }
        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = new List<IPlayer>();
            var counterTerrorists = new List<IPlayer>();
            foreach (var player in players)
            {
                if (player.GetType().Name == "Terrorist")
                {
                    terrorists.Add(player);
                }
                else
                {
                    counterTerrorists.Add(player);
                }
            }

            while (terrorists.Any(t => t.IsAlive) && counterTerrorists.Any(c => c.IsAlive))
            {
                Attack(terrorists, counterTerrorists);
                Attack(counterTerrorists, terrorists);
            }
            if (terrorists.Any(t => t.IsAlive))
            {
                return "Terrorist wins!";
            }
            return "Counter Terrorist wins!";
        }

        private static void Attack(List<IPlayer> attackers, List<IPlayer> defernders)
        {
            foreach (var attacker in attackers)
            {
                foreach (var defender in defernders)
                {
                    if (defender.IsAlive)
                    {
                        int points = attacker.Gun.Fire();
                        defender.TakeDamage(points);                        
                    }

                }
            }
        }
    }
}

