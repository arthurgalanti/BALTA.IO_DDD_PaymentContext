﻿namespace PaymentContext.Domain.Entities;

public class Subscription
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