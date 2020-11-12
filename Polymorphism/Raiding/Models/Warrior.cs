namespace Raiding.Models
{
    class Warrior : BaseHero
    {
        private const int POWER_WARRIOR = 100;
        public Warrior(string name)
            : base(name)
        {
            this.Power = POWER_WARRIOR;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
