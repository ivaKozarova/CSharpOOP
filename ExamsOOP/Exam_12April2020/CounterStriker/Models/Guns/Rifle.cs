namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun
    {
        private const int BULLET_FIRED_AT_ONCE = 10;
        public Rifle(string name, int bulletsCount)
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if(this.BulletsCount < BULLET_FIRED_AT_ONCE)
            {
                return 0;
            }
            this.BulletsCount -= BULLET_FIRED_AT_ONCE;
            return BULLET_FIRED_AT_ONCE;
        }
    }
}
