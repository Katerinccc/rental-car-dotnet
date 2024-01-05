using RentalCar.Domain.Abstractions;

namespace RentalCar.Domain.Vehicles;

public sealed class Vehicle : Entity
{
    public Model? Model { get; private set; }
    public Vin? Vin { get; private set; }
    public Currency? Price { get; private set; }
    public Currency? Maintenance { get; private set; }
    public DateTime? LastRentalDate { get; private set; }
    public Address? Address { get; private set; }
    public List<Accessories>? Accessories { get; private set; } = [];

    public Vehicle(Guid id, Model? model, Vin? vin, Currency? price, Currency? maintenance,
        DateTime? lastRentalDate, Address? address, List<Accessories>? accessories) : base(id)
    {
        Model = model;
        Vin = vin;
        Price = price;
        Maintenance = maintenance;
        LastRentalDate = lastRentalDate;
        Address = address;
        Accessories = accessories;
    }
}