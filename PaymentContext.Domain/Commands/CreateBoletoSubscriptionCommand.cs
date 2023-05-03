﻿using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands;

public class CreateBoletoSubscriptionCommand : Notifiable<Notification>, ICommand
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Document { get; set; }
    public string Email { get; set; }
    
    public string BarCode { get; set; }
    public string BoletoNumber { get; set; }
    public string PaymentNumber { get; set; }
    public DateTime PaidDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public decimal Total { get; set; }
    public decimal TotalPaid { get; set; }
    public string Payer { get; set; }
    public string PayerDocument { get; set; }
    public EDocumentType PayerDocumentType { get; set; }
    public string PayerEmail { get; set; }
    
    public string Street { get; set; }
    public string Number { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
    
    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterThan(FirstName, 3, "Name.FirstName", "FirstName should have at least 3 chars")
            .IsGreaterThan(LastName, 3, "Name.LastName", "LastName should have at least 3 chars")
            .IsLowerThan(FirstName, 40, "Name.FirstName", "FirstName should have no more than 40 chars")
            .IsLowerThan(LastName, 40, "Name.LastName", "LastName should have no more than 40 chars")
        );
    }
}