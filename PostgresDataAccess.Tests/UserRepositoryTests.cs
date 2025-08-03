using PostgresDataAccess.Repositories;
using PostgresDataAccess.Models;
using Microsoft.EntityFrameworkCore;

public class UserRepositoryTests
{
    private AppDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public void AddUser_ShouldIncreaseCount()
    {
        var context = GetInMemoryDbContext();
        var repo = new UserRepository(context);

        repo.Add(new User { Name = "Test User" });

        Assert.Equal(1, context.Users.Count());
    }
}