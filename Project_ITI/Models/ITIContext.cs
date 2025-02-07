using Microsoft.EntityFrameworkCore;

namespace Project_ITI.Models
{
    public class ITIContext:DbContext
    {
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Instractor> Instractors { get; set; }
        public virtual DbSet<CrsREsult>CrsREsults { get; set; }
        public virtual DbSet<Department>Departments { get; set; }
        public virtual DbSet<Trainee> Trainees { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=ITI_Company;Trusted_Connection=True; TrustServerCertificate=True;");
        //}

        public ITIContext(DbContextOptions<ITIContext> dbContext):base (dbContext)
        {
            
        }
        public ITIContext():base()
        {

        }
    }
}
