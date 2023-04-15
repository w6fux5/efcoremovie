using EFCoreMovie.Dtos.CinemaHall;
using EFCoreMovie.Dtos.CinemaOffer;

namespace EFCoreMovie.Dtos.Cinema;

public class CreateCinemaDTO
{
    public string Name { get; set; }

    public double Lattitude { get; set; }

    public double Longitude { get; set; }

    public CreateCinemaOfferDTO CinemaOffer { get; set; }

    public CreateCinemaHallDTO[] CinemaHalls { get; set; }
}
