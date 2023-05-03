using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers;

[TestClass]
public class SubscriptionHandlerTests
{
    [TestMethod]
    public void ShouldReturnErrorWhenDocumentExists()
    {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
        var command = new CreateBoletoSubscriptionCommand();
        command.FirstName = "Arthur";
        command.LastName = "Galanti";
        command.Document = "99999999999";
        command.Email = "arthur@galanti.dev";

        command.BarCode = "2432432424";
        command.BoletoNumber = "234234234234234";

        command.PaymentNumber = "2342455354534";
        command.PaidDate = DateTime.Now;
        command.ExpireDate = DateTime.Now.AddMonths(1);

        command.Total = 600;
        command.TotalPaid = 600;

        command.Payer = "Arthut O Galanti";
        command.PayerDocument = "2342";
        command.PayerDocumentType = EDocumentType.CPF;
        command.PayerEmail = "arthur.galanti@hotmail.com";

        command.Street = "Avenida Caramuru";
        command.Number = "2450";
        command.Neighborhood = "Alto da Boa Vista";
        command.City = "Ribeirão Preto";
        command.State = "São Paulo";
        command.Country = "Brasil";
        command.ZipCode = "14025-710";

        handler.Handle(command);
        Assert.AreEqual(false, handler.IsValid);
    }
}