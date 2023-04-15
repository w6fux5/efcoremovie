using NetTopologySuite.Geometries;

namespace EFCoreMovie.Entities;

public class CinemaEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public Point Location { get; set; } // from NetTopologySuite.Geometries;

    public CinemaDetailEntity CinemaDetail { get; set; }

    public CinemaOfferEntity CinemaOffer { get; set; }

    public HashSet<CinemaHallEntity> CinemaHalls { get; set; } // 效能最好，但是沒辦法按特定順序獲得結果
}
