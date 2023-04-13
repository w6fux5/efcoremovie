namespace EFCoreMovie.Entities;

public class MovieActorEntity
{
    public int MovieId { get; set; }

    public int ActorId { get; set; }

    public string Character { get; set; }

    public int Order { get; set; }

    public MovieEntity Movie { get; set; }

    public ActorEntity Actor { get; set; }
}
