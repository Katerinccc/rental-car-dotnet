using RentalCar.Domain.Vehicles;

namespace RentalCar.Domain.Rentals;

public record PriceDetail(
    Currency PriceForPeriod,
    Currency Maintenance,
    Currency Accessories,
    Currency TotalPrice
);