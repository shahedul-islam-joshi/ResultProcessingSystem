using Microsoft.EntityFrameworkCore;
using ResultProcessingSystem.Models.Domain;

namespace ResultProcessingSystem.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base (options) 
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}
