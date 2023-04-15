using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreMovie.Entities;

public class PersonEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    [InverseProperty("Sender")]
    public List<MessageEntity> SendMessages { get; set; }

    [InverseProperty("Receiver")]
    public List<MessageEntity> ReceivedMessages { get; set; }
}
