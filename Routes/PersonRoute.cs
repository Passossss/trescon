using PersoTrescon.Data;
using PersoTrescon.Models;

namespace PersoTrescon.Routes;

public static class PersonRoute
{
public static void PersonRoutes( this WebApplication app)
{
    var route = app.MapGroup("trescon"); // assim nao precisa escrever um por um



    route.MapPost("trescon", 
        async (PersonRequest req, PersonContext context) =>
        {
            var person = new Person(req.name);
            await context.AddAsync(person);
            await context.SaveChangesAsync(); // salva no banco
            
        });
    //app.MapPost("trescon", () => "");
    //app.MapGet("trescon", () => "");
    //app.MapDelete("trescon", () => "");
    //app.MapGet("trescon", () => new Person ("Gustavo"));;
}
}