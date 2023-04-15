using System.ComponentModel.DataAnnotations;

namespace EFCoreMovie.Dtos.Genre;

public class CreateGenresDTO
{
    [Required]
    public string Name { get; set; }
}
