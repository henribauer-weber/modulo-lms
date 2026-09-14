using Microsoft.EntityFrameworkCore;
using ModuloLMS.Models;

namespace ModuloLMS.Data
{
    public class ModuloLMSContext : DbContext
    {
        public ModuloLMSContext(DbContextOptions<ModuloLMSContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
    }
}
