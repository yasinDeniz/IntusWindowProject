using Microsoft.EntityFrameworkCore;

namespace DatabaseAPI.Models
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions options) :base(options) 
        {
        }

        public DbSet<Order> Order { get; set; }                      
        public DbSet<SubElement> SubElement { get; set; }                      
        public DbSet<Window> Window { get; set; }                      
    }                         
}
