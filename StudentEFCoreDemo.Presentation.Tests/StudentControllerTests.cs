using Moq;
using StudentEfCoreDemo.Domain.Entities;
using StudentEfCoreDemo.Application.Services;
using StudentEfCoreDemo.Application.Interfaces;
using StudentEfCoreDemo.Presentation.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace StudentEfCoreDemo.Presentation.Tests
{
    public class StudentControllerTests
    {

        private readonly Mock<IStudentsService> _studentsServiceMock;
        private readonly StudentsController _studentsControllerMock;

        public StudentControllerTests()
        {
            _studentsServiceMock = new Mock<IStudentsService>();
            _studentsControllerMock = new StudentsController(_studentsServiceMock.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnStudents()
        {
            // Arrange
            var students = new List<Student>
            {
                new Student { Id = 1, FirstName = "Aatos", LastName = "Korpela", Age = 40 },
                new Student { Id = 2, FirstName = "Saimi", LastName = "Rajala", Age = 45 },
                new Student { Id = 3, FirstName = "Ilmari", LastName = "Honkanen", Age = 24}
            };

            _studentsServiceMock.Setup(service => service.GetAllStudentsAsync()).ReturnsAsync(students);
            
            // Act
            var result = await _studentsControllerMock.GetStudents();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedStudents = Assert.IsType<List<Student>>(okResult.Value);
            Assert.Equal(3, returnedStudents.Count);

        }
    }
}