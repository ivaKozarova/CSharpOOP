namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            RaceMotorcycle motor = new RaceMotorcycle(234, 2887);
           motor.Drive(100);
            System.Console.WriteLine(motor.Fuel);
            FamilyCar familyCar = new FamilyCar(75, 32333);
            System.Console.WriteLine($"before drive : {familyCar.Fuel}");
            familyCar.Drive(200);
            System.Console.WriteLine($"after drive {familyCar.Fuel}");



        }
    }
}
