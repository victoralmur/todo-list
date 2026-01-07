using _28.Models;
using Microsoft.EntityFrameworkCore;

namespace _28.Repositories.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Tarea> Tareas { get; set; }
    }
}
