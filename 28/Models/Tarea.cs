using System.ComponentModel.DataAnnotations;

namespace _28.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Titulo { get; set; } = string.Empty;
        [Required]
        [StringLength(maximumLength: 100)]
        public string Descripcion { get; set; } = string.Empty;
        [Required]
        public int Estado { get; set; }
    }
}