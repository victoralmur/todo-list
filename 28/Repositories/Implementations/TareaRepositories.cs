using _28.Models;
using _28.Repositories.Abstractions;
using _28.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace _28.Repositories.Implementations
{
    public class TareaRepositories: ITareaRepositories
    {
        private readonly ApplicationDbContext dbContext;

        public TareaRepositories(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Tarea>> DevuelveTareas()
        {
            List<Tarea> tareas = await dbContext.Tareas.ToListAsync();

            return tareas;
        }

        public async Task NuevaTarea(Tarea tarea)
        {
            await dbContext.Tareas.AddAsync(tarea);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Tarea?> DevuelveTarea(int id)
        {
            //AsNoTracking indica a Entity Framework, ignorar el seguimiento de las entidades obtenidas mediante una consulta,
            //esto significa que EF no las guardará en su caché, no controlará sus modificaciones ni las asociará con un contexto.
            return await dbContext.Tareas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task EditarTarea(Tarea tarea)
        {
            dbContext.Tareas.Update(tarea);
            await dbContext.SaveChangesAsync();
        }

        public async Task EliminarTarea(Tarea tarea)
        {
            dbContext.Tareas.Remove(tarea);
            await dbContext.SaveChangesAsync();
        }
    }
}
