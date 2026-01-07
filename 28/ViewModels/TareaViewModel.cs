using System.ComponentModel.DataAnnotations;

namespace _28.ViewModels
{
    public class TareaViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El titulo es obligatorio")] //La propiedad debe ser obligatorio
        [Display(Name = "Titulo:")] //El nombre, que se utilizara en la etiqueta label en la Vista
        [StringLength(maximumLength: 50, ErrorMessage = "El titulo debe tener 50 caracteres")] //El tamaño de caracteres
        public string Titulo { get; set; } = string.Empty;
        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [Display(Name = "Descripcion:")]
        [StringLength(maximumLength: 100, ErrorMessage = "La descripcion debe tener 100 caracteres")]
        public string Descripcion { get; set; } = default!;
        [Display(Name = "Estado de la tarea:")]
        public EstadosTareaViewModel Estado { get; set; } = new EstadosTareaViewModel();
    }
}
