using PersoTrescon.Data;
using PersoTrescon.Routes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<PersonContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//PersonRoute.PersonRoutes(app);

app.PersonRoutes(); //extensao metodo usado aq

app.UseHttpsRedirection();
app.Run();
