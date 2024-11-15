using System.Text.Json.Serialization;
using AutoMapper;
using AvoanteDigital.Domain.Api.Models;
using AvoanteDigital.Domain.Api.Profiles;
using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Domain.Infra.Data.Context;
using AvoanteDigital.Domain.Infra.Data.Repository;
using AvoanteDigital.Domain.Interfaces;
using AvoanteDigital.Domain.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

// Banco de dados
builder.Services.AddDbContextPool<DataContext>(options => 
    options.UseMySql(DataContextFactory.DbConfig, ServerVersion.AutoDetect(DataContextFactory.DbConfig)));

// Injeção de dependência
builder.Services.AddScoped<IBaseRepository<Customer>, BaseRepository<Customer>>();
builder.Services.AddScoped<IBaseService<Customer>, BaseService<Customer>>();

// Automapper ()
builder.Services.AddAutoMapper(typeof(CustomerMappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
