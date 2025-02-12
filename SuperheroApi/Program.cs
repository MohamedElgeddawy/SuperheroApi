using Microsoft.EntityFrameworkCore;
using SuperheroApi.Data;
using SuperheroApi.Services;
using System.Text.Json.Serialization;
using SuperheroApi.Core;
using SuperheroApi.Data.Data;
using SuperheroApi.Service.Services;
using SuperheroApi.Services.Service;
using SuperheroApi.Data.Repositories;
using SuperheroApi.Services.Services;
using SuperheroApi.Core.Models;


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

// ? Register Database Context
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Register Services
builder.Services.AddScoped<ISuperheroService, SuperheroService>();
builder.Services.AddScoped<ISuperheroRepository, SuperheroRepository>();
builder.Services.AddScoped<IFavoriteSuperheroRepository, FavoriteSuperheroRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
app.UseAuthorization();
app.MapControllers();

app.Run();
