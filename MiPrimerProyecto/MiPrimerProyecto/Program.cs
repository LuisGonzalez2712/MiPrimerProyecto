using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using MiPrimerProyecto.DAL;
using MiPrimerProyecto.Domain.Interfaces;
using MiPrimerProyecto.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Linea de codigo para configurar la DB
builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//contenedor de dependencias
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IStateService, StateService>();
builder.Services.AddTransient<SeederDB>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
SeederData();

void SeederData()
{
    IServiceScopeFactory? scopeFactory = app.Services.GetService<IServiceScopeFactory>();

    using (IServiceScope? scope = scopeFactory.CreateScope())
    {
        SeederDB? service = scope.ServiceProvider.GetService<SeederDB>();
        service.SeederAsync().Wait();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
