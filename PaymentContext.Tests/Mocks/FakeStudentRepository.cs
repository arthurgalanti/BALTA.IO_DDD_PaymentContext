using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Tests.Mocks;

public class FakeStudentRepository : IStudentRepository
{
    public bool DocumentExists(string document)
    {
        return document == "99999999999";
    }

    public bool EmailExists(string email)
    {
        return email == "arthur@galanti.dev";
    }

    public void CreateSubscription(Student student)
    {
    }
}