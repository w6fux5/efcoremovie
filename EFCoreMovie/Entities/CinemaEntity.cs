using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace EFCoreMovie.Entities;

public class CinemaEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    [Precision(precision: 9, scale: 2)]
    public decimal Price { get; set; }

    public Point Location { get; set; } // from NetTopologySuite.Geometries;
}
