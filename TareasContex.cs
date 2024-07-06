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
        modelBuilder.Entity<Categoria>(
            categoria =>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(c => c.Id);
                categoria.Property(c => c.Nombre).HasMaxLength(150).IsRequired();
                categoria.Property(c => c.Descripcion).HasMaxLength(200);
                categoria.HasMany(c => c.Tareas).WithOne(t => t.Categoria).HasForeignKey(t => t.CategoriaId);
            }
        );
        modelBuilder.Entity<Tarea>(
            tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(t => t.TareaId);
                tarea.Property(t => t.Titulo).HasMaxLength(200).IsRequired();
                tarea.Property(t => t.Descripcion).HasMaxLength(200);
                tarea.Property(t => t.FechaCreacion).HasDefaultValueSql("GETDATE()");
                tarea.Ignore(t => t.Resumen);
            }
        );
    }
}