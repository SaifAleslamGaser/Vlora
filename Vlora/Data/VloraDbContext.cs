using Microsoft.EntityFrameworkCore;
using Vlora.Models.Domain;

namespace Vlora.Data
{
    public class VloraDbContext : DbContext
    {
        public VloraDbContext(DbContextOptions<VloraDbContext> options):base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        
    }
}
