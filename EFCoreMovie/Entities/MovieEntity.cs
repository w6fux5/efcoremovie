namespace EFCoreMovie.Entities;

public class MovieEntity
{
    public int Id { get; set; }

    public string Title { get; set; }

    public bool InCinemas { get; set; }

    public DateTime ReleaseDate { get; set; }

    public string PosterURL { get; set; }

    public HashSet<GenreEntity> Genres { get; set; }

    public HashSet<CinemaHallEntity> CinemaHalls { get; set; }

    public HashSet<MovieActorEntity> MoviesActors { get; set; }

}
