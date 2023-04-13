namespace EFCoreMovie.Entities;

public class CinemaHallEntity
{
    public int Id { get; set; }

    public CinemaHallTypeEnum CinemaHallType { get; set; }

    public decimal Cost { get; set; }

    public int CinemaId { get; set; }

    public CinemaEntity Cinema { get; set; }

    public HashSet<MovieEntity> Movies { get; set; }

}
