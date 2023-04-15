using Microsoft.EntityFrameworkCore;

namespace EFCoreMovie.Entities.Seeding;

public static class Module6Seeding
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var mike = new PersonEntity { Id = 1, Name = "Mike" };
        var andy = new PersonEntity { Id = 2, Name = "Andy" };


        var msg1 = new MessageEntity
        {
            Id = 1,
            Content = "Hi, Andy!",
            SenderId = mike.Id,
            ReceiverId = andy.Id
        };

        var msg2 = new MessageEntity
        {
            Id = 2,
            Content = "Hey Mike, how are your!",
            SenderId = andy.Id,
            ReceiverId = mike.Id
        };

        var msg3 = new MessageEntity
        {
            Id = 3,
            Content = "All good, and you!",
            SenderId = mike.Id,
            ReceiverId = andy.Id
        };

        var msg4 = new MessageEntity
        {
            Id = 4,
            Content = "Very good :)",
            SenderId = andy.Id,
            ReceiverId = mike.Id
        };

        modelBuilder.Entity<PersonEntity>().HasData(mike, andy);

        modelBuilder.Entity<MessageEntity>().HasData(msg1, msg2, msg3, msg4);
    }
}
