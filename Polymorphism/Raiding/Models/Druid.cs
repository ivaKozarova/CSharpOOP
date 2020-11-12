namespace Raiding.Models
{
    class Druid : BaseHero
    {
        private const int POWER_DRUID = 80;
        public Druid(string name) 
            : base(name)
        {
            this.Power = POWER_DRUID;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
