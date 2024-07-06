using System.ComponentModel.DataAnnotations;

namespace MinimalApi.Models
{
    public class Categoria
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(150), MinLength(3)]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();

    }
}