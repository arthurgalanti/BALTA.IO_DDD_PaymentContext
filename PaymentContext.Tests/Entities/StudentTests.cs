using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests;

[TestClass]
public class StudentTests
{
    [TestMethod]
    public void TestMethod1()
    {
        var student = new Student(new Name("Arthur", "Galanti"), new Document("123456789", EDocumentType.CPF), new Email("arthur.galanti@hotmail.com"));
        
    }
}