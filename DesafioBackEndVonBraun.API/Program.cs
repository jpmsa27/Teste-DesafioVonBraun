using DesafioBackEndVonBraun.Infraestrutura.ContextDb;
using DesafioBackEndVonBraun.Service.Interfaces;
using DesafioBackEndVonBraun.Service.Interfaces.Auth;
using DesafioBackEndVonBraun.Service.Interfaces.ColaborativeIoT;
using DesafioBackEndVonBraun.Service.Interfaces.Device;
using DesafioBackEndVonBraun.Service.Interfaces.Telnet;
using DesafioBackEndVonBraun.Service.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Diagnostics;
using System.Net.Http.Headers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetSection("ConnectionStrings:DesafioVonBraun").Value;
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API", Version = "v1" });

    // Adicione o esquema de segurança Basic
    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        Description = "Autenticação básica HTTP"
    });

    // Adicione um requisito de segurança global para todas as operações
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "basic"

                }
            },
            new string[] {}
        }
    });
});
builder.Services.AddScoped<DbContext, DesafioVonBraunDbContext>();
builder.Services.AddDbContext<DesafioVonBraunDbContext>(options => options.EnableSensitiveDataLogging().UseNpgsql(connectionString)); 
builder.Services.AddAuthentication("BasicAuthentication")
            .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddScoped<ITelnetCommandService, TelnetCommandService>();

builder.Services.AddHttpClient<ColaborativeIoTService>(client => 
{
    client.BaseAddress = new Uri(builder.Configuration.GetSection("ServicesUrl:ColaborativeIoTServiceUrl").Value);
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json-patch+json"));
}).AddTypedClient<IColaborativeIoTClient>();

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

var app = builder.Build();

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
