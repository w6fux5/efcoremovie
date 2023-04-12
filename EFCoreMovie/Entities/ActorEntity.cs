using System.ComponentModel.DataAnnotations;

namespace EFCoreMovie.Entities;

public class ActorEntity
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Biography { get; set; }

    public DateTime DateOfBirth { get; set; }
}
