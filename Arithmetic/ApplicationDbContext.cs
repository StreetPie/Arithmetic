using System.Configuration;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Arithmetic.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<TeacherClass> TeacherClasses { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Result> Results { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
