﻿using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Subscription : Entity
{
    private IList<Payment> _payments;
    public Subscription(DateTime? expirationDate)
    {
        CreateDate = DateTime.Now;
        LastUpdateDate = DateTime.Now;
        ExpirationDate = expirationDate;
        Active = true;
        _payments = new List<Payment>();
    }

    public DateTime CreateDate { get; private set; }
    public DateTime LastUpdateDate { get; private set; }
    public DateTime? ExpirationDate { get; private set; }
    public bool Active { get; private set; }
    public IReadOnlyCollection<Payment> Payments => _payments.ToArray();

    public void AddPayment(Payment payment)
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterThan(DateTime.Now, payment.PaidDate, "Subscription.Payments", "The payment date should be in future date ")
            );
        _payments.Add(payment);
    }
    
    public void Activate()
    {
        Active = true;
        LastUpdateDate = DateTime.Now;
    }
    
    public void Inactivate()
    {
        Active = false;
        LastUpdateDate = DateTime.Now;
    }
}