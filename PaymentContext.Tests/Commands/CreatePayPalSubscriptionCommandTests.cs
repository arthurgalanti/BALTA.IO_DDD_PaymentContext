using PaymentContext.Domain.Commands;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Commands;

//[TestClass]
public class CreatePayPalSubscriptionCommandTests
{
    [TestMethod]
    public void ShouldReturnErrorWhenNameIsInvalid()
    {
        var command = new CreatePayPalSubscriptionCommand();
        command.name = new Name("Arthur","Gl");

        command.Validate();
        Assert.AreEqual(false, command.IsValid);
    }
}