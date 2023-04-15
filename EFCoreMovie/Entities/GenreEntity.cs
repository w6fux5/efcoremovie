namespace EFCoreMovie.Entities;

public class GenreEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public HashSet<MovieEntity> Movies { get; set; }

}
