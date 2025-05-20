using Microsoft.EntityFrameworkCore;
using api8.Models;

namespace api8.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options)
        {            
        }


        public DbSet<AutorModel> Autores { get; set; }
        public DbSet<LivroModel> Livros { get; set; }
    }
}
