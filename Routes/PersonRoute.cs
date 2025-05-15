using PersoTrescon.Models;

namespace PersoTrescon.Routes;

public static class PersonRoute
{
public static void PersonRoutes( this WebApplication app)
{
    app.MapPost("trescon", () => "");
    app.MapGet("trescon", () => "");
    app.MapDelete("trescon", () => "");
    //app.MapGet("trescon", () => new Person ("Gustavo"));;
}
}