namespace EFCoreMovie.Entities;

public abstract class PaymentEntity
{
    public int Id { get; set; }

    public decimal Amount { get; set; }

    public DateTime PaymentDate { get; set; }

    public PaymentType PaymentType { get; set; }
}

public enum PaymentType
{
    Paypal = 1,
    Card = 2
}