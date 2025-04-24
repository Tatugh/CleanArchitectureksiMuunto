using Moq;
using StudentEfCoreDemo.Domain.Entities;
using StudentEfCoreDemo.Application.Services;
using StudentEfCoreDemo.Application.Interfaces;
using StudentEfCoreDemo.Domain.Interfaces;

namespace StudentEfCoreDemo.Application.Tests
{
    public class StudentServiceTests
    {
        private readonly Mock<IStudentRepository> _studentRepositoryMock;
        private readonly IStudentsService _studentsService;

        public StudentServiceTests()
        {
            _studentRepositoryMock = new Mock<IStudentRepository>();
            _studentsService = new StudentsService(_studentRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllStudentsAsync_ReturnsAllStudents()
        {
            var students = new List<Student>
            {
                new Student { Id = 1, FirstName = "Jari", LastName = "Järvi", Age = 50},
                new Student { Id = 2, FirstName = "Pekka", LastName = "Pelto", Age = 40},
            };

            _studentRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(students);

            // Act
            var result = await _studentsService.GetAllStudentsAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Pelto", result[1].LastName);
        }

        [Fact]
        public async Task GetStudentById_ReturnsOneStudent()
        {
            var student = new Student
            {
                Id = 1,
                FirstName = "Tero",
                LastName = "Tanner",
                Age = 30
            };

            _studentRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(student);

            var result = _studentsService.GetStudentByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(30, result.Result.Age);
        }
    }
}