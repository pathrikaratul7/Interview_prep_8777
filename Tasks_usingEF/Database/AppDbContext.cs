using Microsoft.EntityFrameworkCore;
using Tasks_usingEF.Models;
namespace Tasks_usingEF.Database
{
    public partial class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Division> divisions { get; set; }
        public DbSet<Employee> employees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Division>(div =>
            {
                div.HasKey(divkey => divkey.DIVID);
            });
            modelBuilder.Entity<Projects>(proj =>
            {
                proj.HasKey(projkey => projkey.PID);
            });

            modelBuilder.Entity<Employee>(emp =>
            {
                emp.HasKey(empkey => empkey.EID);
                emp.HasOne(empkey => empkey.division)
                .WithMany()
                .HasForeignKey(empkey => empkey.DIVID)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<EmployeeProjects>(empproj =>
            {
                empproj.HasKey(empprojkey => empprojkey.EPID);
                empproj.HasOne(empprojkey => empprojkey.projects)
                .WithMany()
                .HasForeignKey(empprojkey => empprojkey.PID)
                .OnDelete(DeleteBehavior.Restrict);

                empproj.HasOne(emmp=> emmp.employees)
                .WithMany()
                .HasForeignKey(eemmp=> eemmp.EID)
                .OnDelete(DeleteBehavior.Restrict);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
