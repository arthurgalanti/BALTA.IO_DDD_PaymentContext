using System.Net.Security;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands;

public class CreatePayPalSubscriptionCommand : Notifiable<Notification>, ICommand
{
    public Name Name { get; set; } = null!;
    public string Document { get; set; } = null!;
    public string Email { get; set; } = null!;
    
    public string TransactionCode { get; set; } = null!;
    public string PaymentNumber { get; set; } = null!;
    public DateTime PaidDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public decimal Total { get; set; }
    public decimal TotalPaid { get; set; }
    public string Payer { get; set; } = null!;
    public string PayerDocument { get; set; } = null!;
    public EDocumentType PayerDocumentType { get; set; }
    public string PayerEmail { get; set; } = null!;

    public string Street { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string Neighborhood { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    
    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterThan(Name.FirstName, 3, "Cmd.Name.FirstName", "FirstName should have at least 3 chars")
            .IsLowerThan(Name.FirstName, 40, "Cmd.Name.FirstName", "FirstName should have no more than 40 chars")
            .IsGreaterThan(Name.LastName, 3, "Cmd.Name.LastName", "LastName should have at least 3 chars")
            .IsLowerThan(Name.LastName, 40, "Cmd.Name.LastName", "LastName should have no more than 40 chars")
        );
    }
}