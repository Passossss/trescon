using Microsoft.EntityFrameworkCore;
using PersoTrescon.Models;

namespace PersoTrescon.Data;

public class PersonContext : DbContext
{
    public DbSet<Person> People { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=person.sqlite");
        
        base.OnConfiguring(optionsBuilder);
    }
    
}