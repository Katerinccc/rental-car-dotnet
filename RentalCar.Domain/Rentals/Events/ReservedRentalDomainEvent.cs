using RentalCar.Domain.Abstractions;

namespace RentalCar.Domain.Rentals.Events;
public sealed record ReservedRentalDomainEvent(Guid RentalId) : IDomainEvent
{
}