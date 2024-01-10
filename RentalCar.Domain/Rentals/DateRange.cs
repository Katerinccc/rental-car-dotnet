namespace RentalCar.Domain.Rentals;
public sealed record DateRange
{
    public DateRange()
    {
    }

    public DateOnly Start { get; init; }
    public DateOnly End { get; init; }

    public int DaysNumber => Start.DayNumber - End.DayNumber;

    public static DateRange Create(DateOnly start, DateOnly end)
    {
        if (start > end)
        {
            throw new ApplicationException("Date end is previous to date start");
        }

        return new DateRange()
        {
            Start = start,
            End = end
        };
    }
}