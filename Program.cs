using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalApi;
using MinimalApi.Models;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<TareasContext>(options => options.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos creada: " + dbContext.Database.IsInMemory());
});
app.MapGet("/api/tareas", ([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.Tareas.Include(b=>b.Categoria));
});
app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext,[FromBody] Tarea tarea) =>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    await dbContext.Tareas.AddAsync(tarea);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
});
app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbContext,[FromBody] Tarea tarea, [FromRoute] Guid id) =>
{
    var tareaactual = await dbContext.Tareas.FindAsync(id);
    if (tareaactual == null)
    {
        return Results.NotFound();
    }
    tareaactual.Titulo = tarea.Titulo;
    tareaactual.Descripcion = tarea.Descripcion;
    tareaactual.PrioridadTarea = tarea.PrioridadTarea;
    dbContext.Tareas.Update(tareaactual);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
});
app.MapDelete("/api/tareas/{id}", async ([FromServices] TareasContext dbContext,[FromRoute] Guid id) =>
{
    var tareaactual = await dbContext.Tareas.FindAsync(id);
    if (tareaactual == null)
    {
        return Results.NotFound();
    }
   dbContext.Tareas.Remove(tareaactual);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
});

app.Run();
