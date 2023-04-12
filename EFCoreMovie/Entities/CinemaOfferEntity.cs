namespace EFCoreMovie.Entities;

public class CinemaOfferEntity
{
    public int Id { get; set; }

    public DateTime Begin { get; set; }

    public DateTime End { get; set; }

    public decimal DiscountPercentage { get; set; }

    public int CinemaId { get; set; }
}
