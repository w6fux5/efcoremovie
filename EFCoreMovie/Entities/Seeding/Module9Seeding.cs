using Microsoft.EntityFrameworkCore;

namespace EFCoreMovie.Entities.Seeding
{
    public static class Module9Seeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var invoice1 = new InvoiceEntity() { Id = 1, CreateAt = new DateTime(2022, 1, 24) };

            var detail1 = new List<InvoiceDetailEntity>()
            {
                new InvoiceDetailEntity(){Id = 3, InvoiceId = invoice1.Id, Price = 350.99m},
                new InvoiceDetailEntity(){Id = 4, InvoiceId = invoice1.Id, Price = 10},
                new InvoiceDetailEntity(){Id = 5, InvoiceId = invoice1.Id, Price = 45.50m},
            };

            var invoice2 = new InvoiceEntity() { Id = 2, CreateAt = new DateTime(2022, 1, 24) };

            var detail2 = new List<InvoiceDetailEntity>()
            {
                new InvoiceDetailEntity(){Id = 6, InvoiceId = invoice2.Id, Price = 17.99m},
                new InvoiceDetailEntity(){Id = 7, InvoiceId = invoice2.Id, Price = 14},
                new InvoiceDetailEntity(){Id = 8, InvoiceId = invoice2.Id, Price = 45},
                new InvoiceDetailEntity(){Id = 9, InvoiceId = invoice2.Id, Price = 100},
            };

            var invoice3 = new InvoiceEntity() { Id = 3, CreateAt = new DateTime(2022, 1, 24) };

            var detail3 = new List<InvoiceDetailEntity>()
            {
                new InvoiceDetailEntity(){Id = 10, InvoiceId = invoice3.Id, Price = 371},
                new InvoiceDetailEntity(){Id = 11, InvoiceId = invoice3.Id, Price = 114.99m},
                new InvoiceDetailEntity(){Id = 12, InvoiceId = invoice3.Id, Price = 425},
                new InvoiceDetailEntity(){Id = 13, InvoiceId = invoice3.Id, Price = 1000},
                new InvoiceDetailEntity(){Id = 14, InvoiceId = invoice3.Id, Price = 5},
                new InvoiceDetailEntity(){Id = 15, InvoiceId = invoice3.Id, Price = 2.99m},
            };

            var invoice4 = new InvoiceEntity() { Id = 4, CreateAt = new DateTime(2022, 1, 24) };

            var detail4 = new List<InvoiceDetailEntity>()
            {
                new InvoiceDetailEntity(){Id = 16, InvoiceId = invoice4.Id, Price = 50},
            };

            modelBuilder.Entity<InvoiceEntity>().HasData(invoice1, invoice2, invoice3, invoice4);
            modelBuilder.Entity<InvoiceDetailEntity>().HasData(detail1);
            modelBuilder.Entity<InvoiceDetailEntity>().HasData(detail2);
            modelBuilder.Entity<InvoiceDetailEntity>().HasData(detail3);
            modelBuilder.Entity<InvoiceDetailEntity>().HasData(detail4);
        }
    }
}
