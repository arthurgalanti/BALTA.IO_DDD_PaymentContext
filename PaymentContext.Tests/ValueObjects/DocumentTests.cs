using PaymentContext.Domain.ValueObjects;
using PaymentContext.Domain.Enums;

namespace PaymentContext.Tests.ValueObjects;

//[TestClass]
public class DocumentTests
{
    // Red, Green, Refactor
    [TestMethod]
    public void ShouldReturnErrorWhenCPNJIsInvalid()
    {
        var doc = new Document("123", EDocumentType.CNPJ);
        Assert.IsTrue(!doc.IsValid);
    }
    
    [TestMethod]
    public void ShouldReturnSucessWhenCPNJIsValid()
    {
        var doc = new Document("12345678910111", EDocumentType.CNPJ);
        Assert.IsTrue(doc.IsValid);
    }
    
    [TestMethod]
    public void ShouldReturnErrorWhenCPFIsInvalid()
    {
        var doc = new Document("123", EDocumentType.CPF);
        Assert.IsTrue(!doc.IsValid);
    }
    
    [TestMethod]
    [DataTestMethod]
    [DataRow("19742534063")]
    [DataRow("79717081069")]
    [DataRow("41174755091")]
    public void ShouldReturnSucessWhenCPFIsValid(string cpf)
    {
        var doc = new Document(cpf, EDocumentType.CPF);
        Assert.IsTrue(doc.IsValid);
    }
}