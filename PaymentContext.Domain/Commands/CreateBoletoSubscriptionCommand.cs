using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands;

public class CreateBoletoSubscriptionCommand : Notifiable<Notification>, ICommand
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Document { get; set; } = null!;
    public string Email { get; set; } = null!;
    
    public string BarCode { get; set; } = null!;
    public string BoletoNumber { get; set; } = null!;
    public string PaymentNumber { get; set; } = null!;
    public DateTime PaidDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public decimal Total { get; set; }
    public decimal TotalPaid { get; set; }
    public string Payer { get; set; } = null!;
    public string PayerDocument { get; set; } = null!;
    public EDocumentType PayerDocumentType { get; set; }
    public string PayerEmail { get; set; } = string.Empty;
    
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
            .IsGreaterThan(FirstName, 3, "Name.FirstName", "FirstName should have at least 3 chars")
            .IsGreaterThan(LastName, 3, "Name.LastName", "LastName should have at least 3 chars")
            .IsLowerThan(FirstName, 40, "Name.FirstName", "FirstName should have no more than 40 chars")
            .IsLowerThan(LastName, 40, "Name.LastName", "LastName should have no more than 40 chars")
        );
    }
}