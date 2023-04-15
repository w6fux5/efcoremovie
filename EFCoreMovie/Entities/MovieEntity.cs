namespace EFCoreMovie.Entities;

public class MovieEntity
{
    public int Id { get; set; }

    public string Title { get; set; }

    public bool InCinemas { get; set; }

    public DateTime ReleaseDate { get; set; }

    public string PosterURL { get; set; }

    public List<GenreEntity> Genres { get; set; }

    public List<CinemaHallEntity> CinemaHalls { get; set; }

    public List<MovieActorEntity> MovieActors { get; set; }

}
