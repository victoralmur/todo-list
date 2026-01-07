using _28.Models;
using _28.ViewModels;

namespace _28.Services.Mapping
{
    public static class MappingExtensions
    {
        //Tarea -> TareaViewModel
        public static TareaViewModel MapToTareaViewModel(this Tarea tarea)
        {
            return new TareaViewModel()
            {
                Id = tarea.Id,
                Titulo = tarea.Titulo,
                Descripcion = tarea.Descripcion,
                Estado = new EstadosTareaViewModel()
                {
                    ValorSeleccionadoEstadosTarea = tarea.Estado.ToString(),
                    TextoSeleccionadoEstadosTarea = new EstadosTareaViewModel().EstadosTarea.FirstOrDefault(x => x.Value == tarea.Estado.ToString())?.Text ?? string.Empty
                }
            };
        }
        //TareaViewModel -> Tarea
        public static Tarea MapToTarea(this TareaViewModel tareaViewModel)
        {
            return new Tarea()
            {
                Id = tareaViewModel.Id,
                Titulo = tareaViewModel.Titulo,
                Descripcion = tareaViewModel.Descripcion,
                Estado = Int16.Parse(tareaViewModel.Estado.ValorSeleccionadoEstadosTarea)
            };
        }
    }
}
