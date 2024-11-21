using MagicVenteStore.Data;
using MagicVenteStore.Metier.MetierServices;
using MagicVenteStore.Metier.Models;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy => policy.WithOrigins("http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials());
});



// Add services to the container.
builder.Services.AddDbContext<MagicVenteStoreContext>(option => option.UseSqlite(builder.Configuration.GetConnectionString("databaselink")));
builder.Services.AddScoped<IProduitsServiceAPI,ProduitsManager>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IClientsServiceAPI,ClientsManager>();



var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Ajout de données test (optionnel)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MagicVenteStoreContext>();
    context.Database.EnsureCreated();
    if (!context.Clients.Any())
    {
        context.Clients.AddRange(new Client
        {
            Numero = "1",
            Pseudo = "admin",
            MotDePasse = "password",
            Nom = "Admin",
            Prenom = "Test"
        },

        new Client
        {
            Numero = "2",
            Pseudo = "elrond",
            MotDePasse = "password",
            Nom = "Adar",
            Prenom = "Mongor"
        }

        );
        context.SaveChanges();
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
