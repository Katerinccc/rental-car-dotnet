namespace RentalCar.Domain.Vehicles;

public interface IVehicleRepository
{
    Task<Vehicle?> GetByIdAsync(Guid id);

    void Add(Vehicle vehicle);
}