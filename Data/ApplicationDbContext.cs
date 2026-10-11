using Microsoft.EntityFrameworkCore;
using ProductoMVC.Models;

namespace ProductoMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Producto> Productos { get; set; }
    }
}