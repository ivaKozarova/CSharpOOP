namespace Raiding.Models
{
    class Paladin : BaseHero
    {
        private const int POWER_PALADIN = 100;
        public Paladin(string name) 
            : base(name)
        {
            this.Power = POWER_PALADIN;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
