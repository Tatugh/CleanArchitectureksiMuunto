using Microsoft.EntityFrameworkCore;
using StudentEfCoreDemo.Infrastructure.Data;
using StudentEfCoreDemo.Infrastructure.Repositories;
using StudentEfCoreDemo.Domain.Entities;

namespace StudentEFCoreDemo.Infrastructure.Tests
{
    public class StudentRepositoryTests
    {
        public async Task<StudentContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<StudentContext>()
                .UseInMemoryDatabase(databaseName: "DefaultConnection")
                .Options;

            var databaseContext = new StudentContext(options);

            databaseContext.Database.EnsureCreated();

            if (await databaseContext.Students.CountAsync() <= 0) 
            {
                databaseContext.Students.Add(new Student { Id = 1, FirstName = "Rane", LastName = "Roina", Age = 30 });
                await databaseContext.SaveChangesAsync();
            }
            return databaseContext;
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnStudents()
        {
            // Arrange
            var dbContext = await GetDatabaseContext();
            var repository = new StudentRepository(dbContext);

            // Act
            var result = await repository.GetAllAsync();

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal("Rane", result[0].FirstName);
        }
    }
}