using FirstProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Contexts
{
    public class AppDbContext :DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        { 
                
        }
        public DbSet<content> Contents { get; set; }
    }
}
