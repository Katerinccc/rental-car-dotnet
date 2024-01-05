namespace RentalCar.Domain.Vehicles;

public record Address(
    string Country,
    string State,
    string City,
    string Street,
    string Number
);