﻿using System.Text.Json;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests;

 //[TestClass]
public class StudentTests
{
    private readonly Name _name;
    private readonly Document _document;
    private readonly Address _address;
    private readonly Email _email;
    private readonly Student _student;
    private readonly Subscription _subscription;

    public StudentTests()
    {
        _name = new Name("Arthur", "Galanti");
        _document = new Document("30738814091", EDocumentType.CPF);
        _address = new Address("Rua das Flores", "235", "Vila Dionísio", "Batatais", "SP", "Brasil", "14025-710");
        _email = new Email("arthur.galanti@hotmail.com");
        _student = new Student(_name, _document, _email);
        _subscription = new Subscription(null);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenHadActiveSubscription()
    {
        var payment = new PaypalPayment( DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Galanti Car",_document, _address, _email, "");
        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);
        _student.AddSubscription(_subscription);

        Assert.IsTrue(!_student.IsValid);
    }
    
    [TestMethod]
    public void ShouldReturnErrorWhenHadActiveSubscriptionHasNoPayment()
    {
        _student.AddSubscription(_subscription);

        Assert.IsTrue(!_student.IsValid);
    }
    
    [TestMethod]
    public void ShouldReturnSucessWhenAddSubscription()
    {
        var payment = new PaypalPayment( DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Galanti Car",_document, _address, _email, "");
        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);

        Assert.IsTrue(_student.IsValid);
    }
}