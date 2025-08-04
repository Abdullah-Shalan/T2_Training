using Microsoft.EntityFrameworkCore;
using Products_API.DAL;
using Products_API.Models;


var builder = WebApplication.CreateBuilder(args);

// Register EF Core DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register UnitOfWork
builder.Services.AddScoped<UnitOfWork>();

builder.Services.AddEndpointsApiExplorer();     // REQUIRED for Swagger
builder.Services.AddSwaggerGen();               // REQUIRED for Swagger
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();                           // REQUIRED
    app.UseSwaggerUI();                         // REQUIRED
}

app.MapControllers();

app.Run();