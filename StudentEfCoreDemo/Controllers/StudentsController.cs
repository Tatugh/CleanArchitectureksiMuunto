using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentEfCoreDemo.Infrastructure.Data;
using StudentEfCoreDemo.Domain.Entities;
using StudentEfCoreDemo.Application.Interfaces;

namespace StudentEfCoreDemo.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class StudentsController : ControllerBase
    {
        private readonly IStudentsService _studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentsService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("Test")]
        public async Task<string> GetStudentsDemo()
        {
            return "Test";
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _studentsService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> PostStudent(Student student)
        {
            await _studentsService.AddStudentAsync(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _studentsService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            await _studentsService.DeleteStudentAsync(id);

            return NoContent();
        }
    }
}



