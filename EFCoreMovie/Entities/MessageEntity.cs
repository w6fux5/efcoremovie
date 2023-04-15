namespace EFCoreMovie.Entities;

public class MessageEntity
{
    public int Id { get; set; }

    public string Content { get; set; }

    public int SenderId { get; set; }

    public PersonEntity Sender { get; set; }

    public int ReceiverId { get; set; }

    public PersonEntity Receiver { get; set; }
}
