using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovie.Entities.Configurations;

public class CardPaymentConfig : IEntityTypeConfiguration<CardPayment>
{
    public void Configure(EntityTypeBuilder<CardPayment> builder)
    {
        builder.Property(p => p.Last4Digits).HasColumnType("char(4)").IsRequired();

        var payment1 = new CardPayment()
        {
            Id = 3,
            PaymentType = PaymentType.Card,
            PaymentDate = new DateTime(2022, 3, 1),
            Amount = 99,
            Last4Digits = "1234"
        };


        var payment2 = new CardPayment()
        {
            Id = 4,
            PaymentType = PaymentType.Card,
            PaymentDate = new DateTime(2023, 1, 1),
            Amount = 22,
            Last4Digits = "9876"
        };

        builder.HasData(payment1, payment2);
    }
}



