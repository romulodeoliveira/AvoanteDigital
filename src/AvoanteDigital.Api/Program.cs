using System.Text;
using System.Text.Json.Serialization;
using AvoanteDigital.Api.Profiles;
using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Domain.Helper;
using AvoanteDigital.Infra.Context;
using AvoanteDigital.Infra.Repository;
using AvoanteDigital.Domain.Interfaces;
using AvoanteDigital.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // informações personalizadas sobre a documentação do Swagger
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "1.0",
        Title = "Avoante Digital",
        Description = "Projeto destinado a portfólio. Sinta-se à vontade ao utilizá-lo.",
        Contact = new OpenApiContact
        {
            Name = "Rômulo de Oliveira",
            Email = "devromulodeoliveira@gmail.com",
            Url = new Uri("https://github.com/romulodeoliveira"),
        },
        License = new OpenApiLicense
        {
            Name = "Licença",
            Url = new Uri("https://github.com/romulodeoliveira/"),
        }
    });
    
    // Informações do oauth2
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenHelper.Key)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("IsActiveAndAdmin", policy =>
    {
        policy.RequireRole("Admin");
        policy.RequireClaim("IsActive", "True");
    });
    
    options.AddPolicy("IsActiveAndAdminAndManager", policy =>
    {
        policy.RequireRole("Admin", "Manager");
        policy.RequireClaim("IsActive", "True");
    });
});

// Banco de dados
builder.Services.AddDbContextPool<DataContext>(options => 
    options.UseMySql(DataContextFactory.DbConfig, ServerVersion.AutoDetect(DataContextFactory.DbConfig)));

// Injeção de dependência
builder.Services.AddScoped<IBaseRepository<Customer>, BaseRepository<Customer>>();
builder.Services.AddScoped<IBaseService<Customer>, BaseService<Customer>>();

builder.Services.AddScoped<IBaseRepository<Ebook>, BaseRepository<Ebook>>();
builder.Services.AddScoped<IBaseService<Ebook>, BaseService<Ebook>>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// Automapper ()
builder.Services.AddAutoMapper(typeof(CustomerMappingProfile));
builder.Services.AddAutoMapper(typeof(UserMappingProfile));
builder.Services.AddAutoMapper(typeof(EbookMappingProfile));

var app = builder.Build();

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
