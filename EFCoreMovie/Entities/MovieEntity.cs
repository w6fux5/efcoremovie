namespace EFCoreMovie.Entities;

public class MovieEntity
{
    public int Id { get; set; }

    public string Title { get; set; }

    public bool InCinemas { get; set; }

    public DateTime ReleaseDate { get; set; }

    public string PosterURL { get; set; }
}
