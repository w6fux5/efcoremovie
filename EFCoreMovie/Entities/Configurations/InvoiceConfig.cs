using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovie.Entities.Configurations;

public class InvoiceConfig : IEntityTypeConfiguration<InvoiceEntity>
{
    public void Configure(EntityTypeBuilder<InvoiceEntity> builder)
    {
        builder.HasMany(typeof(InvoiceDetailEntity)).WithOne().HasForeignKey("InvoiceId"); ;

    }
}
