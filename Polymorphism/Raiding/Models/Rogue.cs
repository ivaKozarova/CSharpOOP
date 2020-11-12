namespace Raiding.Models
{
    class Rogue : BaseHero
    {
        private const int POWER_ROGUE = 80;
        public Rogue(string name) 
            : base(name)
        {
            this.Power = POWER_ROGUE;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
