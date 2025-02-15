<<<<<<< HEAD
﻿using Microsoft.EntityFrameworkCore;
=======
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SuperheroApi.Core;
using SuperheroApi.Core.Repositories;
>>>>>>> e85ae720da2a1dd1cdf9ff192fecd25b12ce94dc
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

<<<<<<< HEAD
// Register AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));
=======
void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<ApiDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<ApiDbContext>()
        .AddDefaultTokenProviders();

    services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(builder.Configuration["Jwt:Key"])),

            ClockSkew = TimeSpan.Zero // Disable clock skew for testing
        };

        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine("Authentication failed: " + context.Exception.Message);
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                Console.WriteLine("Token validated successfully.");
                return Task.CompletedTask;
            }
        };
    });

    services.AddMemoryCache();
    services.AddHttpClient<ISuperheroApiService, SuperheroApiService>();
    services.Configure<SuperheroApiService>(builder.Configuration.GetSection("SuperheroApi"));
    services.AddControllers();
    services.AddAuthorization(options =>
    {
        options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
        options.AddPolicy("UserOnly", policy => policy.RequireRole("User"));
    });
}
>>>>>>> e85ae720da2a1dd1cdf9ff192fecd25b12ce94dc

// Register Logging
builder.Services.AddLogging();

// Add FluentValidation services
builder.Services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

// ? Register Database Context
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        var config = builder.Configuration;
//        var secretKey = config["JwtSettings:Secret"];
//        if (string.IsNullOrEmpty(secretKey))
//        {
//            throw new InvalidOperationException("JWT Secret Key is not configured.");
//        }

//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = config["JwtSettings:Issuer"],
//            ValidAudience = config["JwtSettings:Audience"],
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
//        };

//    });

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var config = builder.Configuration;
        var secretKey = config["JwtSettings:Secret"];
        options.RequireHttpsMetadata = false;
        options.SaveToken = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = config["JwtSettings:Issuer"],
            ValidAudience = config["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
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

ConfigureServices(builder.Services);

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
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
