using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovie.Entities.Configurations;

public class PaymentConfig : IEntityTypeConfiguration<PaymentEntity>
{
    public void Configure(EntityTypeBuilder<PaymentEntity> builder)
    {

        builder.Property(prop => prop.Amount).HasPrecision(18, 2).IsRequired();

        builder.HasDiscriminator(prop => prop.PaymentType)
            .HasValue<PaypalPayment>(PaymentType.Paypal)
            .HasValue<CardPayment>(PaymentType.Card);
    }
}
