using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private IMap map;
        private GunRepository guns;
        private PlayerRepository players;
        public Controller()
        {
            this.map = new Map();
            this.guns = new GunRepository();
            this.players = new PlayerRepository();

        }
        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun = CreateGun(type, name, bulletsCount);
            this.guns.Add(gun);
            return $"Successfully added gun {name}.";
        }


        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IPlayer player = CreatePlayer(type, username, health, armor, gunName);
            this.players.Add(player);
            return $"Successfully added player {username}.";
        }
        public string Report()
        {
            var result = this.players.Models.OrderBy(p => p.GetType().Name)
                .ThenByDescending(p => p.Health)
                .ThenBy(p => p.Username).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var player in result)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();

        }

        public string StartGame()
        {           
            return this.map.Start(this.players.Models.ToList());
        }
        private IGun CreateGun(string type, string name, int bulletsCount)
        {
            IGun gun = null;
            if (type == "Pistol")
            {
                gun = new Pistol(name, bulletsCount);
            }
            else if (type == "Rifle")
            {
                gun = new Rifle(name, bulletsCount);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }
            return gun;
        }
        private IPlayer CreatePlayer(string type, string username, int health, int armor, string gunName)
        {
            IPlayer player = null;
            IGun gun = this.guns.FindByName(gunName);

            if (type == "Terrorist")
            {
                if (gun == null)
                {
                    throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
                }
                player = new Terrorist(username, health, armor, gun);
            }
            else if (type == "CounterTerrorist")
            {
                if (gun == null)
                {
                    throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
                }
                player = new CounterTerrorist(username, health, armor, gun);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }
            return player;
        }

    }
}
