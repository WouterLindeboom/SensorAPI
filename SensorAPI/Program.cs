using Microsoft.EntityFrameworkCore;
using SensorAPI.Models;
using System.Drawing.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Use in-memory DB
builder.Services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("SensorApi"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
SeedDB(app);

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


//Seed DB with some cities & measurements
static void SeedDB(WebApplication app)
{
    var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetService<ApiContext>()!;
    var city1 = new City()
    {
        Name = "Rotterdam",
        Country = "Netherlands"
    };
    var city2 = new City()
    {
        Name = "Amsterdam",
        Country = "Netherlands"
    };

    var measurement1 = new Measurement()
    {
        Temperature = 20.0,
        Humidity = 5,
        Date = DateTime.Now,
        CityId = 1
    };

    db.Cities.Add(city1);
    db.Cities.Add(city2);
    db.Measurements.Add(measurement1);
    db.SaveChanges();
}