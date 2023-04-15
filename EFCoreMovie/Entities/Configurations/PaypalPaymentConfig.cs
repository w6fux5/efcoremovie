using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovie.Entities.Configurations;

public class PaypalPaymentConfig : IEntityTypeConfiguration<PaypalPayment>
{
    public void Configure(EntityTypeBuilder<PaypalPayment> builder)
    {
        builder.Property(p => p.EmailAddress).IsRequired();


        var payment1 = new PaypalPayment()
        {
            Id = 1,
            PaymentDate = new DateTime(2022, 3, 2),
            PaymentType = PaymentType.Paypal,
            Amount = 10,
            EmailAddress = "test@example.com"
        };



        var payment2 = new PaypalPayment()
        {
            Id = 2,
            PaymentDate = new DateTime(2022, 1, 2),
            PaymentType = PaymentType.Paypal,
            Amount = 110,
            EmailAddress = "cool@example.com"
        };

        builder.HasData(payment1, payment2);
    }
}
