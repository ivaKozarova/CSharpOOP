namespace Vehicles.Contracts
{
    public interface IVehicle : IDrivable , IRefuelable
    {
        double FuelQuantity { get;}
        double FuelConsumption { get;}
        double TankCapacity { get; }


    }
}
