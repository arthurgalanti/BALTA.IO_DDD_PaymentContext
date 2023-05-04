using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Student : Entity
{
    private IList<Subscription> _subscriptions;
    private bool _hasSubscriptonActive;
    public Student(Name name, Document document, Email email, Address address)
    {
        Name = name;
        Document = document;
        Email = email;
        Address = address;
        _subscriptions = new List<Subscription>();
        
        AddNotifications(name, document, email);
    }

    public Name Name { get; private set; }
    public Document Document { get; private set; }
    public Email Email { get; private set; }
    public Address? Address { get; private set; }
    public IReadOnlyCollection<Subscription> Subscriptions => _subscriptions.ToArray();

    public void AddSubscription(Subscription subscription)
    {
        foreach (var sub in _subscriptions)
        {
            if (sub.Active)
                _hasSubscriptonActive = true;
        }
        if (!_hasSubscriptonActive) 
            _subscriptions.Add(subscription);
        
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsFalse(_hasSubscriptonActive, "Student.Subscriptions","You already have an active subscription")
            .AreNotEquals(0, subscription.Payments.Count, "Student.Subscription.Payments", "This subscription there isn't payments"));
        // if (hasSubscriptonActive)
        //     AddNotification("Student.Subscriptions", "You already have an active subscription");
    }
}