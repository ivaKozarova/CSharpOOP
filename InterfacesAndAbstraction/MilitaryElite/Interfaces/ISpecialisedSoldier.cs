namespace MilitaryElite.Interfaces
{
   public enum Corps
    {
        Airforces,
        Marines
    }
    public interface ISpecialisedSoldier
    {
        public Corps Corps { get; }
    }
}
