using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace _28.ViewModels
{
    public class EstadosTareaViewModel
    {
        [Required(ErrorMessage = "El estado de la tarea es obligatorio")]
        public string ValorSeleccionadoEstadosTarea { get; set; }
        public string TextoSeleccionadoEstadosTarea { get; set; }
        public List<SelectListItem> EstadosTarea { get; set; }

        public EstadosTareaViewModel()
        {
            ValorSeleccionadoEstadosTarea = string.Empty;
            TextoSeleccionadoEstadosTarea = string.Empty;
            EstadosTarea = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = "A hacer",
                    Value = "1"
                },
                 new SelectListItem
                {
                    Text = "En progreso",
                    Value = "2"
                },
                  new SelectListItem
                {
                    Text = "Finalizado",
                    Value = "3"
                }
            };
        }
    }
}
