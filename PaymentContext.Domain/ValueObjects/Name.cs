using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterThan(FirstName, 3, "Name.FirstName", "FirstName should have at least 3 chars")
            .IsLowerThan(FirstName, 40, "Name.FirstName", "FirstName should have no more than 40 chars")
            .IsGreaterThan(LastName, 3, "Name.LastName", "LastName should have at least 3 chars")
            .IsLowerThan(LastName, 40, "Name.LastName", "LastName should have no more than 40 chars")
        );
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}