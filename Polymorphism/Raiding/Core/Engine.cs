using System;
using System.Linq;
using System.Collections.Generic;

using Raiding.Models;
using Raiding.Contracts;
using Raiding.Factories;
using Raiding.IO;
using Raiding.IO.Contracts;

namespace Raiding.Core
{
    class Engine : IEngine
    {
        private IReadable reader;
        private IWritable writer;
        private readonly ICollection<BaseHero> heroes;
        private HeroFactory heroFactory;

        public Engine()
        {
           this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
            this.heroes = new List<BaseHero>();
            this.heroFactory = new HeroFactory();
        }

        public void Run()
        {
            CreateRaidGroup();
            var bossPower = int.Parse(this.reader.ReadLine());
            var totalHeroesPower = 0;

            if(this.heroes.Any())
            {
                foreach (var hero in heroes)
                {
                    this.writer.WriteLine(hero.CastAbility());
                    totalHeroesPower += hero.Power;
                }
            }
            this.writer.WriteLine(bossPower - totalHeroesPower > 0 ?
                "Defeat..." : "Victory!");

        }

        private void CreateRaidGroup()
        {
            int count = int.Parse(this.reader.ReadLine());
            while (count > this.heroes.Count)
            {
                var name = this.reader.ReadLine();
                var type = this.reader.ReadLine();
                try
                {
                    BaseHero hero = heroFactory.CreateHero(type, name);
                    heroes.Add(hero);

                }
                catch (Exception msg)
                {
                    this.writer.WriteLine(msg.Message);
                }
            }
        }
    }
}
