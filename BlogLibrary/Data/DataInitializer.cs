using BlogLibrary.Models;
using BlogWeb.Data;
using Microsoft.EntityFrameworkCore;
using Bogus;

namespace BlogLibrary.Data;

public class DataInitializer
{
    private readonly ApplicationDbContext _dbContext;

    public DataInitializer(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void MigrateData()
    {
        _dbContext.Database.Migrate();
        SeedBlogUsers();
        _dbContext.SaveChanges();
    }

    private void SeedBlogUsers()
    {
        if (_dbContext.BlogUsers.Any()) return;

        var rng = new Random();
        var userCount = rng.Next(20, 51); // Generate a random number between 20 and 50

        var faker = new Faker();

        for (int i = 0; i < userCount; i++)
        {
            var user = new BlogUser
            {
                //test
                UserName = faker.Internet.UserName(),
                Email = faker.Internet.Email(),
                PasswordHash = Guid.NewGuid().ToString(), // This is just a placeholder. In a real application, you should use a proper password hashing function.
                FullName = faker.Name.FullName(),
                Bio = faker.Lorem.Sentence(),
                IsAdmin = rng.Next(2) == 0, // Randomly assign true or false
                IsAuthor = rng.Next(2) == 0, // Randomly assign true or false
                IsModerator = rng.Next(2) == 0, // Randomly assign true or false
                IsEnabled = true,
                MemberSince = DateTime.Now
            };

            _dbContext.BlogUsers.Add(user);
        }

        _dbContext.SaveChanges();
    }

}