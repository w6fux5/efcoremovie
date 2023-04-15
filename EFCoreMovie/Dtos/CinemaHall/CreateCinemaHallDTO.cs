using EFCoreMovie.Entities;

namespace EFCoreMovie.Dtos.CinemaHall;

public class CreateCinemaHallDTO
{
    public double Cost { get; set; }

    public CinemaHallTypeEnum CinemaHallType { get; set; }
}
