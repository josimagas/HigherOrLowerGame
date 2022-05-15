using HigherOrLowerGame.Api.Configuration;
using HigherOrLowerGame.Api.Infra;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AutoMapper;
    
var builder = WebApplication.CreateBuilder(args);
var assembly = Assembly.GetExecutingAssembly();

builder.Services.AddSwaggerConfiguration();
builder.Services.AddDependencyInjection();

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEntityFrameworkNpgsql()
.AddDbContext<AppDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwaggerConfiguration();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
