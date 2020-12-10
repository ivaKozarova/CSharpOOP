namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        private const int BULLET_FIRED_AT_ONCE = 1;
        public Pistol(string name, int bulletsCount)
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if(this.BulletsCount == 0)
            {
                return 0;
            }
            this.BulletsCount -= BULLET_FIRED_AT_ONCE;
            return BULLET_FIRED_AT_ONCE;
        }
    }
}
