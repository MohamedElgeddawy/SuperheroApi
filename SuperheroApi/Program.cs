using Microsoft.EntityFrameworkCore;
using SuperheroApi.Core;
using SuperheroApi.Core.Repositories;
using SuperheroApi.Data;
using SuperheroApi.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Register HttpClient
builder.Services.AddHttpClient<ISuperheroApiService, SuperheroApiService>();

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Register services
builder.Services.AddScoped<ISuperheroApiService, SuperheroApiService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


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
