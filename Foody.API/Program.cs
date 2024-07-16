using Foody.API.Extensions.DI;
using Foody.Core.Application.Extensions.DI;
using Foody.Infrastructure.Persistence;
using Foody.Infrastructure.Persistence.Extensions.DI;
using Foody.Infrastructure.Persistence.Models;
using Foody.Shared.DI;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var assemblies = new Assembly[] { Assembly.GetExecutingAssembly(), Assembly.Load("Foody.Core.Domain"), Assembly.Load("Foody.Core.Application"), Assembly.Load("Foody.Infrastructure.Persistence") };
builder.Services.AddApplication();
builder.Services.AddProfiles(assemblies);
builder.Services.AddCQRS(assemblies);
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

app.MapControllers().WithGroupName("api");

app.Run();
