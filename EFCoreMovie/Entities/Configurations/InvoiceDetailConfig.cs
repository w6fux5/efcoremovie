using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovie.Entities.Configurations;

public class InvoiceDetailConfig : IEntityTypeConfiguration<InvoiceDetailEntity>
{
    public void Configure(EntityTypeBuilder<InvoiceDetailEntity> builder)
    {
        //builder.Property(p => p.Total).HasComputedColumnSql("Quantity * Price", stored: true);  // 如果是複雜的計算可以考慮保存到數據庫，後續的查詢就不用再計算一次

        builder.Property(p => p.Total).HasComputedColumnSql("Quantity * Price"); // 因為計算很快，所以可以不用保存到數據庫，每次查詢的時候再計算
    }
}
