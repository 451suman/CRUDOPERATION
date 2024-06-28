using CRUDOPERATION.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDOPERATION.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { 
        }
        
        public DbSet<Category> categories { get; set; }
    }
}
