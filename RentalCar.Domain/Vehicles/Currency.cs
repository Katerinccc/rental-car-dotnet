namespace RentalCar.Domain.Vehicles;

public record Currency(decimal Ammount, CurrencyType CurrencyType)
{
    public static Currency operator +(Currency first, Currency second)
    {
        if (first.CurrencyType != second.CurrencyType)
        {
            throw new InvalidOperationException("Currency type must be the same");
        }

        return new Currency(first.Ammount + second.Ammount, first.CurrencyType);
    }

    public static Currency Zero() => new(0, CurrencyType.None);

    public static Currency Zero(CurrencyType currencyType) => new(0, currencyType);

    public bool IsZero() => this == Zero(CurrencyType);
}