using System.ComponentModel.DataAnnotations;

namespace EFCoreMovie.Entities;

public class GenreEntity
{
    public int Id { get; set; }


    [Required]
    [StringLength(maximumLength: 150)]
    public string Name { get; set; }
}
