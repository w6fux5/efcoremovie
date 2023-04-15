using System.ComponentModel.DataAnnotations;

namespace EFCoreMovie.Entities;

public class CinemaDetailEntity
{
    public int Id { get; set; }

    [Required]
    public string History { get; set; }

    public string Values { get; set; }

    public string Missions { get; set; }

    public string CodeOfConduct { get; set; }

    public CinemaEntity Cinema { get; set; }
}
