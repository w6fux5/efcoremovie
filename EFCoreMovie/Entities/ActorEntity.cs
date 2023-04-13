using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreMovie.Entities;

public class ActorEntity
{
    public int Id { get; set; }

    [Required]
    [StringLength(maximumLength: 150)]
    public string Name { get; set; }

    public string Biography { get; set; }

    [Column(TypeName = "Date")]
    public DateTime? DateOfBirth { get; set; } // 允許 null

    public HashSet<MovieActorEntity> MoviesActors { get; set; }
}
