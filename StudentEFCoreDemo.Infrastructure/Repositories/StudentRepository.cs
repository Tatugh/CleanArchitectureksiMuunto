using StudentEfCoreDemo.Infrastructure.Data;
using StudentEfCoreDemo.Domain.Interfaces;
using StudentEfCoreDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentEfCoreDemo.Domain.Entities;
using StudentEfCoreDemo.Infrastructure.Data;

namespace StudentEfCoreDemo.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentContext _studentContext;

        public StudentRepository (StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _studentContext.Students.ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _studentContext.Students.FindAsync(id);
        }

        public async Task AddAsync(Student student)
        {
            await _studentContext.Students.AddAsync(student);
            await _studentContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _studentContext.Students.Update(student);
            await _studentContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _studentContext.Students.FindAsync(id);
            if (student != null)
            {
                _studentContext.Students.Remove(student);
                await _studentContext.SaveChangesAsync();
            }
        }
    }
}
