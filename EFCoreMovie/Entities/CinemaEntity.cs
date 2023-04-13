using NetTopologySuite.Geometries;

namespace EFCoreMovie.Entities;

public class CinemaEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public Point Location { get; set; } // from NetTopologySuite.Geometries;

    public CinemaOfferEntity CinemaOffer { get; set; }

    public HashSet<CinemaHallEntity> CinemaHalls { get; set; } // 效能最好，但是沒辦法按特定順序獲得結果
    // public List<CinemaHallEntity> CinemaHalls { get; set; }  // 更具體的指定類型
    // public ICollection<CinemaHallEntity> CinemaHalls { get; set; } // 和 List 差不多
}
