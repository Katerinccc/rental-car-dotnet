using RentalCar.Domain.Abstractions;
using RentalCar.Domain.Users.Events;

namespace RentalCar.Domain.Users;

public sealed class User : Entity
{
    private User(Guid id) : base(id)
    {
    }

    public Name? Name { get; private set; }
    public LastName? LastName { get; private set; }
    public Email? Email { get; private set; }

    public static User Create(Name name, LastName lastName, Email email)
    {
        var user = new User(new Guid())
        {
            Name = name,
            LastName = lastName,
            Email = email
        };

        user.RaiseDomainEvents(new UserCreatedDomainEvent(user.Id));
        return user;
    }
}