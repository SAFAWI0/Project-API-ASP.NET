using Microsoft.EntityFrameworkCore;
using project.Models;

namespace project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet <User> Users { get; set; }
        public DbSet <Product> Products { get; set; }
        public DbSet <Categorie> Categorias { get; set; } 
    }
}
