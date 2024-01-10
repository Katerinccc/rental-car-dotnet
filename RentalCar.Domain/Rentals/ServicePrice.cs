using RentalCar.Domain.Vehicles;

namespace RentalCar.Domain.Rentals;

public class ServicePrice
{
    public PriceDetail CalculatePrice(Vehicle vehicle, DateRange period)
    {
        var typeCurrency = vehicle.Price!.CurrencyType;

        var priceForPeriod = new Currency(
            period.DaysNumber * vehicle.Price.Ammount
            , typeCurrency);

        decimal percentageChange = 0;

        foreach (var accessory in vehicle.Accessories)
        {
            percentageChange += accessory switch
            {
                Accessories.AppleCar or Accessories.AndroidCar => 0.05m,
                Accessories.AirConditioning => 0.1m,
                Accessories.Maps => 0.01m,
                _ => 0
            };
        }

        var accessoriesCharge = Currency.Zero(typeCurrency);

        if (percentageChange > 0)
        {
            accessoriesCharge = new Currency(priceForPeriod.Ammount * percentageChange, typeCurrency);
        };

        var totalPrice = Currency.Zero(typeCurrency);
        totalPrice += priceForPeriod;

        if (!vehicle.Maintenance!.IsZero())
        {
            totalPrice += vehicle.Maintenance;
        }

        totalPrice += accessoriesCharge;

        return new PriceDetail(priceForPeriod, vehicle.Maintenance, accessoriesCharge, totalPrice);
    }
}