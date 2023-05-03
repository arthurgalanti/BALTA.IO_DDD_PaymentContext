using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands;

public class CreatePayPalSubscriptionCommand : Notifiable<Notification>, ICommand
{
    public Name name { get; set; }
    public string Document { get; set; }
    public string Email { get; set; }
    
    public string TransactionCode { get; set; }
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
            .IsGreaterThan(name.FirstName, 3, "Name.FirstName", "FirstName should have at least 3 chars")
            .IsLowerThan(name.FirstName, 40, "Name.FirstName", "FirstName should have no more than 40 chars")
            .IsGreaterThan(name.LastName, 3, "Name.LastName", "LastName should have at least 3 chars")
            .IsLowerThan(name.LastName, 40, "Name.LastName", "LastName should have no more than 40 chars")
        );
    }
}