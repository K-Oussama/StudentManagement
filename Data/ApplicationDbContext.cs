using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentManagmentSystem.Models;

namespace StudentManagmentSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<StudentManagmentSystem.Models.Student> Student { get; set; } = default!;
        public DbSet<StudentManagmentSystem.Models.Course> Course { get; set; } = default!;
        public DbSet<StudentManagmentSystem.Models.Module> Module { get; set; } = default!;
        public DbSet<StudentManagmentSystem.Models.Evaluation> Evaluation { get; set; } = default!;
    }
}
