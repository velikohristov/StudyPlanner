using Microsoft.EntityFrameworkCore;
using StudyPlanner.Models;

namespace StudyPlanner.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<StudyNote> StudyNotes { get; set; }
    }
}