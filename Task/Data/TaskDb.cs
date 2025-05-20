using System.Data;
using Microsoft.EntityFrameworkCore;
using Task.Models;

namespace Task.Data;

public class TaskDb(DbContextOptions<TaskDb> options) : DbContext(options)
{
    public DbSet<Tarefa> Tarefas { get; set; }
}