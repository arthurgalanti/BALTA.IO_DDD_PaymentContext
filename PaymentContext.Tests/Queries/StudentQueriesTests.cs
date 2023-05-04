using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Queries;

[TestClass]
public class StudentQueriesTests
{
    private IList<Student> _students;

    public StudentQueriesTests()
    {
        _students = new List<Student>();
        
        for (var i = 0; i < 10; i++)
        {
            _students.Add(new Student(
                new Name("Aluno", $"Galanti{i}"),
                new Document($"1111111111{i}", EDocumentType.CPF),
                new Email($"{i}@galanti.dev"),
                new Address()
            ));
        }
    }

    [TestMethod]
    public void ShouldReturnNullWhenDocumentNotExists()
    {
        var exp = StudentQueries.GetStudentInfo("12345678911");
        var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

        Assert.AreEqual(null, studn);
    }

    [TestMethod]
    public void ShouldReturnStudentWhenDocumentExists()
    {
        var exp = StudentQueries.GetStudentInfo("11111111111");
        var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

        Assert.AreNotEqual(null, studn);
    }
    
    [TestMethod]
    public void ShouldReturnEmailWhenDocumentExists()
    {
        var exp = StudentQueries.GetStudentInfo("11111111119");
        var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

        Assert.AreEqual("9@galanti.dev", studn?.Email.Address);
    }
    
}