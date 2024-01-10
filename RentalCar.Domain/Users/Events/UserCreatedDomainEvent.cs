using RentalCar.Domain.Abstractions;

namespace RentalCar.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;