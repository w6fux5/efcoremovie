using System.ComponentModel.DataAnnotations;

namespace EFCoreMovie.Entities;

public class GenreEntity
{
    public int Id { get; set; }

    [ConcurrencyCheck] // Column level => 不能修改同一個 column, 但是可以同時修改一個 row 裡面不同的 column
    public string Name { get; set; }

    public HashSet<MovieEntity> Movies { get; set; }

    [Timestamp]
    public byte[] Versioin { get; set; }

}
