using RentalCar.Domain.Abstractions;
using RentalCar.Domain.Rentals.Events;
using RentalCar.Domain.Vehicles;

namespace RentalCar.Domain.Rentals;

public sealed class Rental : Entity
{
    public Rental(Guid id) : base(id)
    {
    }

    private Rental(Guid id, RentalStatus status, DateRange rentalDuration, Guid vehicleId, Guid userId,
        Currency valueForPeriod, Currency maintenance, Currency accessories, Currency totalValue,
        DateTime creationDate) : base(id)
    {
        Status = status;
        RentalDuration = rentalDuration;
        VehicleId = vehicleId;
        UserId = userId;
        ValueForPeriod = valueForPeriod;
        Maintenance = maintenance;
        Accessories = accessories;
        TotalValue = totalValue;
        CreationDate = creationDate;
    }

    public RentalStatus? Status { get; private set; }
    public DateRange? RentalDuration { get; private set; }
    public Guid? VehicleId { get; private set; }
    public Guid? UserId { get; private set; }
    public Currency? ValueForPeriod { get; private set; }
    public Currency? Maintenance { get; private set; }
    public Currency? Accessories { get; private set; }
    public Currency? TotalValue { get; private set; }
    public DateTime? CreationDate { get; private set; }
    public DateTime? ConfirmationDate { get; private set; }
    public DateTime? RefusedDate { get; private set; }
    public DateTime? CancellationDate { get; private set; }
    public DateTime? CompletionDate { get; private set; }

    public static Rental MakeReservation(Guid vehicleId, Guid userId, DateRange duration, PriceDetail priceDetail)
    {
        var rental = new Rental(Guid.NewGuid(), RentalStatus.Reserved, duration, vehicleId, userId,
            priceDetail.PriceForPeriod, priceDetail.Maintenance, priceDetail.Accessories, priceDetail.TotalPrice, DateTime.Now);

        rental.RaiseDomainEvents(new ReservedRentalDomainEvent(rental.Id));

        return rental;
    }
}