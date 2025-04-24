using StudentEfCoreDemo.Domain.Entities;
using Xunit;

namespace StudentEfCoreDemo.Domain.Tests
{
    public class StudentTests
    {
        [Fact]
        public void Student_Should_Have_Valid_Properties()
        {
            var student = new Student
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Testonen",
                Age = 44,
            };

            Assert.Equal(1, student.Id );
            Assert.Equal("Test", student.FirstName);
            Assert.Equal("Testonen", student.LastName);
            Assert.Equal(44, student.Age);
        }
    }
}