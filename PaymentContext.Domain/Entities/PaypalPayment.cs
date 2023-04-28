﻿namespace PaymentContext.Domain.Entities;

public class PaypalPayment  : Payment
{
    public PaypalPayment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, string document, string address, string email, string transactionCode) : base(paidDate, expireDate, total, totalPaid, payer, document, address, email)
    {
        TransactionCode = transactionCode;
    }

    public string TransactionCode { get; set; }
}