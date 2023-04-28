using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests;

[TestClass]
public class StudentTests
{
    [TestMethod]
    public void TestMethod1()
    {
        var student = new Student("Arthur", "Galanti", "123456789", "arthur.galanti@hotmail.com");
        
    }
}