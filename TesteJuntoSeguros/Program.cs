using System.Configuration;
using System.Text;
using Elastic.Apm.NetCoreAll;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using TesteJuntoSeguros.Application.AuthenticationContext.Settings;
using TesteJuntoSeguros.Application.UserContext.Factories.ConcreteCreatorHttpAction;
using TesteJuntoSeguros.Application.UserContext.Factories.Creator;
using TesteJuntoSeguros.Application.UserContext.Interfaces.Factories;
using TesteJuntoSeguros.Configurations;
using TesteJuntoSeguros.Domain.AuthenticationContext.Interface;
using TesteJuntoSeguros.Domain.UserContext.Interfaces;
using TesteJuntoSeguros.Infrastructure.AuthenticationContext.Repositories;
using TesteJuntoSeguros.Infrastructure.CommomContext;
using TesteJuntoSeguros.Infrastructure.UserContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatRServices();

builder.Services.AddSerilog(builder.Configuration, "API Observability");
Log.Information("Starting API");
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddHttpContextAccessor();

builder.Services.AddSingleton<DataContext>();
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IHttpAction, CreateUser>();
builder.Services.AddScoped<IHttpAction, DeleteUser>();
builder.Services.AddScoped<IHttpAction, UpdateUser>();
builder.Services.AddScoped<IHttpAction, GetUser>();
builder.Services.AddScoped<IHttpActionFactory, HttpActionFactory>();

builder.Services.AddSwaggerGen(options =>
{

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Cabeçalho Authorization usando Bearer scheme. Exemplo: \"Bearer {token}\"",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
});

var key = Encoding.ASCII.GetBytes(SettingsSecret.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAllElasticApm(Configuration);


app.UseSerilog();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

//app.UseAllElasticApm(builder.Configuration);

app.Run();
