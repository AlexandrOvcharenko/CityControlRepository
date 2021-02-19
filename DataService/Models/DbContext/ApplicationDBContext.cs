using DataService.Models;
using Microsoft.EntityFrameworkCore;

namespace DataService.models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<House> Houses { get; set; }
    }
}   