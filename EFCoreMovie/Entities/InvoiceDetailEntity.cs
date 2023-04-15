using Microsoft.EntityFrameworkCore;

namespace EFCoreMovie.Entities;

public class InvoiceDetailEntity
{
    public int Id { get; set; }

    public int InvoiceId { get; set; }

    public string Product { get; set; }

    [Precision(18, 2)]
    public decimal Price { get; set; }

}
