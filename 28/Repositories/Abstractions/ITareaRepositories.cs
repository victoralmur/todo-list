using _28.Models;

namespace _28.Repositories.Abstractions
{
    public interface ITareaRepositories
    {
        Task<List<Tarea>> DevuelveTareas();
        Task NuevaTarea(Tarea tarea);
        Task<Tarea?> DevuelveTarea(int id);
        Task EditarTarea(Tarea tarea);
        Task EliminarTarea(Tarea tarea);
    }
}
