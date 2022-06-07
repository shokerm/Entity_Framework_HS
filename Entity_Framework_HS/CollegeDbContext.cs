using Microsoft.EntityFrameworkCore;
namespace Entity_Framework_HS
{
    public class CollegeDbContext: DbContext
    {
        public DbSet<Student> Students  { get; set; }
        public DbSet<Course> Courses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Server=MOSHE-DELL-PC;Database=CollegeDb;Trusted_Connection = True;");

        }
    }
}
