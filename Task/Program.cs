using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Task.Data;
using Task.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TaskDb>(options =>
    options.UseInMemoryDatabase("TaskDb"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "TaskMinimalAPI", Version = "v1" });
});

var app = builder.Build();

app.MapGet("/", () => "New Task - trescon!");

app.MapGet("/tarefas", async (TaskDb db) => await db.Tarefas.ToListAsync());

app.MapGet("/tarefas/{id}", async (string id, TaskDb db) => await db.Tarefas.FindAsync(id) is Tarefa tarefa ? Results.Ok(tarefa) : Results.NotFound());

app.MapPost("/tarefas", async (Tarefa tarefa, TaskDb db) =>
{
    db.Tarefas.Add(tarefa);
    await db.SaveChangesAsync();
    return Results.Created($"/tarefas/{tarefa.Id}", tarefa);
});
app.MapPut("/tarefas/{id}", async (string id, Tarefa tarefaAtualizada, TaskDb db) =>
{
    var tarefa = await db.Tarefas.FindAsync(id);

    if (tarefa is null)
    {
        return Results.NotFound();
    }

    tarefa.AtualizarTarefa(tarefaAtualizada.Nome,
        tarefaAtualizada.Detalhes,
        tarefaAtualizada.Concluido);
    
    await db.SaveChangesAsync();
    return Results.NoContent();
});
app.MapDelete("tarefa/{id},", async (string id, TaskDb db) =>
{
    var tarefa = await db.Tarefas.FindAsync(id);
    if (tarefa is null)
    {
        return Results.NotFound();
    }

    db.Tarefas.Remove(tarefa);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
