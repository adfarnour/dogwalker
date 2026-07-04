using Microsoft.EntityFrameworkCore;
using Application.Features.Dogs.Commands;
using Domain.Repositories;
using API;
using Persistence.Context;
using Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssembly(
        typeof(CreateDogCommand)
        .Assembly)
);

builder.Services.AddScoped<IDogRepository, DogRepository>();
builder.Services.AddDbContext<AppDbContext>(opt => 
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy.WithOrigins("http://localhost:5173") // Dein exakter Vite-React-Port
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Erzwingt, dass die JSON-Ausgabe exakt den TypeScript-Namen entspricht (camelCase)
        options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
    });


var app = builder.Build();

app.UseCors("AllowReactApp");


/* using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if(!context.Dogs.Any())
    {
        var testOwner = new Domain.Entities.Owner
        {
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Name = "Henry Habib",
            Email = "habib@gmail.com",
        };
        context.Owners.Add(testOwner);
        context.SaveChanges();
    }
} */

app.MapControllers();

app.Run();
