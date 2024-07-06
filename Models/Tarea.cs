using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalApi.Models;
public class Tarea
{
    [Key]
    public Guid TareaId { get; set; }
    [Required,ForeignKey("CategoriaId")]
    public Guid CategoriaId { get; set; }
    [Required, MaxLength(200), MinLength(3)]
    public string? Titulo { get; set; }
    public string? Descripcion { get; set; }
    public Prioridad PrioridadTarea { get; set; }
    public bool Completada { get; set; }
    public virtual Categoria? Categoria { get; set; }
    public DateTime FechaCreacion { get; set; }
    [NotMapped]
    public string  Resumen { get; set; }
}
public enum Prioridad
{
    Baja = 1,
    Media = 2,
    Alta = 3
}