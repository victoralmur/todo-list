using _28.Models;
using _28.Repositories.Abstractions;
using _28.Services.Abstractions;
using _28.Services.Mapping;
using _28.ViewModels;

namespace _28.Services.Implementations
{
    public class TareaServices: ITareaServices
    {
        private readonly ITareaRepositories tareaRepositories;

        public TareaServices(ITareaRepositories tareaRepositories)
        {
            this.tareaRepositories = tareaRepositories;
        }

        public async Task<List<TareaViewModel>> DevuelveTareas()
        {
            return (await tareaRepositories.DevuelveTareas()).Select(tarea => tarea.MapToTareaViewModel()).ToList();
        }

        public async Task NuevaTarea(TareaViewModel tareaViewModel)
        {
            await tareaRepositories.NuevaTarea(tareaViewModel.MapToTarea());
        }

        public async Task<TareaViewModel?> DevuelveTarea(int id)
        {
            var tarea = await tareaRepositories.DevuelveTarea(id);

            return tarea?.MapToTareaViewModel();
        }

        public async Task EditarTarea(TareaViewModel tareaViewModel)
        {
            await tareaRepositories.EditarTarea(tareaViewModel.MapToTarea());
        }

        public async Task EliminarTarea(TareaViewModel tareaViewModel)
        {
            await tareaRepositories.EliminarTarea(tareaViewModel.MapToTarea());
        }
    }
}
