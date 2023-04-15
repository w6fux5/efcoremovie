namespace EFCoreMovie.Entities;

public class CardPayment : PaymentEntity
{
    public string Last4Digits { get; set; }
}



public class PaypalPayment : PaymentEntity
{
    public string EmailAddress { get; set; }
}