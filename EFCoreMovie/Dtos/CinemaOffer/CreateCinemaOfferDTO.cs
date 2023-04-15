using System.ComponentModel.DataAnnotations;

namespace EFCoreMovie.Dtos.CinemaOffer;

public class CreateCinemaOfferDTO
{
    [Range(1, 100)]
    public double DiscountPercentage { get; set; }

    public DateTime Begin { get; set; }

    public DateTime End { get; set; }
}