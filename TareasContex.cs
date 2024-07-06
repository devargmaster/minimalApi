using Microsoft.EntityFrameworkCore;
using MinimalApi.Models;

namespace MinimalApi;
public class TareasContext: DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }

    public TareasContext(DbContextOptions<TareasContext> options): base(options){}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoriasInit = new()
        {
            new Categoria { Id = Guid.NewGuid(), Nombre = "Trabajo", Descripcion = "Tareas de trabajo", Peso = 1 },
            new Categoria { Id = Guid.NewGuid(), Nombre = "Personal", Descripcion = "Tareas personales", Peso = 2 },
            new Categoria { Id = Guid.NewGuid(), Nombre = "Estudio", Descripcion = "Tareas de estudio", Peso = 3 }
        };
        modelBuilder.Entity<Categoria>(
            categoria =>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(c => c.Id);
                categoria.Property(c => c.Nombre).HasMaxLength(150).IsRequired();
                categoria.Property(c => c.Descripcion).HasMaxLength(200).IsRequired(false);
                categoria.HasMany(c => c.Tareas).WithOne(t => t.Categoria).HasForeignKey(t => t.CategoriaId);
                categoria.Property(p=>p.Peso);
                categoria.HasData(categoriasInit);
            }
        );
        List<Tarea> tareasInit = new()
        {
            new Tarea { TareaId = Guid.NewGuid(), CategoriaId = categoriasInit[0].Id, Titulo = "Reunión", Descripcion = "Reunión de trabajo", PrioridadTarea = Prioridad.Media, Completada = false },
            new Tarea { TareaId = Guid.NewGuid(), CategoriaId = categoriasInit[1].Id, Titulo = "Comprar pan", Descripcion = "Ir a la panadería", PrioridadTarea = Prioridad.Baja, Completada = false },
            new Tarea { TareaId = Guid.NewGuid(), CategoriaId = categoriasInit[2].Id, Titulo = "Estudiar C#", Descripcion = "Estudiar C# con Visual Studio", PrioridadTarea = Prioridad.Alta, Completada = false }
        };
        modelBuilder.Entity<Tarea>(
            tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(t => t.TareaId);
                tarea.Property(t => t.Titulo).HasMaxLength(200).IsRequired();
                tarea.Property(t => t.Descripcion).HasMaxLength(200).IsRequired(false);
                tarea.Property(t => t.FechaCreacion).HasDefaultValueSql("GETDATE()");
                tarea.Ignore(t => t.Resumen);
                tarea.HasData(tareasInit);
            }
        );
    }
}