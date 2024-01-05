namespace RentalCar.Domain.Vehicles;

public record CurrencyType
{
    public static readonly CurrencyType UsD = new("USD");
    public static readonly CurrencyType Eur = new("EUR");
    public static readonly CurrencyType None = new("");

    public string Code { get; init; }

    private CurrencyType(string code) => Code = code;

    public static readonly IReadOnlyCollection<CurrencyType> All = new[] { UsD, Eur };

    public static CurrencyType FromCode(string code)
    {
        return All.FirstOrDefault(c => c.Code == code) ?? throw new ApplicationException("The currency type is invalid.");
    }
}