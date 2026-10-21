using Microsoft.EntityFrameworkCore;
namespace EventInfrastructure
{
    public class AppdbContext : DbContext
    {
        public AppdbContext(DbContextOptions<AppdbContext> Options) : base(Options)
        {
           
                
        }
    }
}
