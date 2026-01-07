using _28.Models;
using _28.ViewModels;

namespace _28.Services.Abstractions
{
    public interface ITareaServices
    {
        Task<List<TareaViewModel>> DevuelveTareas();
        Task NuevaTarea(TareaViewModel tareaViewModel);
        Task<TareaViewModel?> DevuelveTarea(int id);
        Task EditarTarea(TareaViewModel tareaViewModel);
        Task EliminarTarea(TareaViewModel tareaViewModel);
    }
}
