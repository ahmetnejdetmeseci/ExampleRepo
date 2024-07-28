using API.Data;
using API.Interfaces;
using API.Repository;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();

#region Mapping Profiles

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#endregion


#region Dependency Injection

builder.Services.AddScoped<IPokemonInterface, PokemonRepository>();
builder.Services.AddScoped<ICategoryInterface, CategoryRepository>();
builder.Services.AddScoped<IOwnerInterface, OwnerRepository>();
builder.Services.AddScoped<IReviewInterface, ReviewRepository>();
builder.Services.AddScoped<IReviewerInterface, ReviewerRepository>();


#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


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
