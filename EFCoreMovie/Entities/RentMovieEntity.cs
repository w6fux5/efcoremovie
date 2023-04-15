namespace EFCoreMovie.Entities;

public class RentMovieEntity
{
    public int Id { get; set; }

    public int MovieId { get; set; }

    public MovieEntity Movie { get; set; }

    public int PaymentId { get; set; }

    public PaymentEntity Payment { get; set; }


}
