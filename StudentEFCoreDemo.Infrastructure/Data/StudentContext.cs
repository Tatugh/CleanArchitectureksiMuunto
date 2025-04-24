using Microsoft.EntityFrameworkCore;
using StudentEfCoreDemo.Domain.Entities;
using System.Collections.Generic;

namespace StudentEfCoreDemo.Infrastructure.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; } = null!;
    }
}
