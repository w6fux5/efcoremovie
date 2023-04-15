using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreMovie.Entities;

public class ActorEntity
{
    public int Id { get; set; }


    private string _name;

    [Required]
    [StringLength(maximumLength: 150)]
    public string Name
    {
        get { return _name; }

        // TOm hOlLanD  => Tom Holland
        set
        {
            _name = string.Join(' ', value
                .Split(' ')
                .Select(n => n[0].ToString().ToUpper() + n.Substring(1).ToLower())
                .ToArray()
                );
        }
    }

    public string Biography { get; set; }

    [Column(TypeName = "Date")]
    public DateTime? DateOfBirth { get; set; } // 允許 null


    // 不要把 Age 加到數據庫
    [NotMapped]
    public int? Age
    {
        get
        {
            if (!DateOfBirth.HasValue)
            {
                return null;
            }

            var bod = DateOfBirth.Value;

            var age = DateTime.Today.Year - bod.Year;

            if (new DateTime(DateTime.Today.Year, bod.Month, bod.Day) > DateTime.Today)
            {
                age--;
            }

            return age;
        }
    }

    public HashSet<MovieActorEntity> MoviesActors { get; set; }
}
