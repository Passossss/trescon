using Microsoft.EntityFrameworkCore;
using PersoTrescon.Data;
using PersoTrescon.Models;

namespace PersoTrescon.Routes;

public static class PersonRoute
{
    public static void PersonRoutes(this WebApplication app)
    {
        var route = app.MapGroup("trescon"); // assim nao precisa escrever um por um


        route.MapPost("",
            async (PersonRequest req, PersonContext context) =>
            {
                var person = new Person(req.name, req.sobrenome);
                await context.AddAsync(person);
                await context.SaveChangesAsync(); // salva no banco

            });
        route.MapGet("", async (PersonContext context) =>
        {
            var person = await context.People.ToListAsync();
            return Results.Ok(person);

        });

        route.MapPut("{id:guid}", async (Guid id, PersonRequest req, PersonContext context) =>
        {
            var person = await context.People.FirstOrDefaultAsync(x => x.Id == id);
            if (person == null)
            {
                return Results.NotFound();
            }

            person.MudarNome(req.name, req.sobrenome);
            await context.SaveChangesAsync();
            return Results.Ok(person);
        });

        route.MapDelete("{id:guid}", async (Guid id, PersonContext context) =>
        {
            var person = await context.People.FirstOrDefaultAsync(x => x.Id == id);
            if (person == null)
                return Results.NotFound();
            
            person.Status();
            
            await context.SaveChangesAsync();
            return Results.Ok(person);
            


        });
    }
}