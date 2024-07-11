using Foody.API.DI;
using Foody.Infrastructure.Persistence;
using Foody.Infrastructure.Persistence.DI;
using Foody.Infrastructure.Persistence.Models;
using Foody.Shared.DI;
using Microsoft.AspNetCore.Identity;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddProfiles(Assembly.GetExecutingAssembly(), Assembly.Load("Foody.Core.Domain"), Assembly.Load("Foody.Core.Application"), Assembly.Load("Foody.Infrastructure.Persistence"));
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiConfiguration();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

        await context.SeedAsync(userManager, roleManager); // Seed de datos
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the DB.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
