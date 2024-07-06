using System.ComponentModel.DataAnnotations;

namespace MinimalApi.Models
{
    public class Categoria
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(150), MinLength(3)]
        public string Nombre { get; set; }=string.Empty;
        public string Descripcion { get; set; }=string.Empty;

        public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();

    }
}