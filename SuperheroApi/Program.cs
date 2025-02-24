
﻿using Microsoft.EntityFrameworkCore;

using SuperheroApi.Data;
using SuperheroApi.Services;
using System.Text;
using System.Text.Json.Serialization;
using SuperheroApi.Core;
using SuperheroApi.Data.Data;
using SuperheroApi.Service.Services;
using SuperheroApi.Services.Service;
using SuperheroApi.Data.Repositories;
using SuperheroApi.Services.Services;
using SuperheroApi.Core.Models;
using SuperheroApi.Service.IServices;
using FluentValidation;
using FluentValidation.AspNetCore;

using SuperheroApi.Service.Services.Validators;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;



var builder = WebApplication.CreateBuilder(args);


// ? Add services to the container (only one `AddControllers()`)
builder.Services.AddControllers(options =>
{
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
})
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

// Learn more about configuring Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Register AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));


// Register Logging
builder.Services.AddLogging();

// Add FluentValidation services
builder.Services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

// ? Register Database Context
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


// Add swagger Authentication
builder.Services.AddSwaggerGen(c=>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Superhero API", Version = "v1" });

// Add JWT Authentication
c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
{
    In = ParameterLocation.Header,
    Description = "Please enter a valid token",
    Name = "Authorization",
    Type = SecuritySchemeType.Http,
    BearerFormat = "JWT",
    Scheme = "Bearer"
});

c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[] {}
        }
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Secret"]))
        };
    });


// ✅ Add Identity Services
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<ApiDbContext>()
    .AddDefaultTokenProviders();


// ✅ Register UserManager & SignInManager
builder.Services.AddScoped<UserManager<AppUser>>();
builder.Services.AddScoped<SignInManager<AppUser>>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

// Register Services
builder.Services.AddScoped<ISuperheroService, SuperheroService>();
builder.Services.AddScoped<ISuperheroRepository, SuperheroRepository>();
builder.Services.AddScoped<IFavoriteSuperheroRepository, FavoriteSuperheroRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddLogging(logging => logging.AddConsole().SetMinimumLevel(LogLevel.Debug));

// ? Register External API Client
builder.Services.AddHttpClient<ISuperheroExternalService, SuperheroExternalService>();
builder.Services.AddScoped<ISuperheroExternalService, SuperheroExternalService>();

// ? Register Caching
builder.Services.AddMemoryCache();

var app = builder.Build();

// ? Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Superhero API v1"));
}


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();



app.MapControllers();

app.Run();
