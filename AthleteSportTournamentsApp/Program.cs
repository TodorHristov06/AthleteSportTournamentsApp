using AthleteSportTournamentsApp.Data;
using AthleteSportTournamentsApp.Repositories;
using AthleteSportTournamentsApp.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.UseLazyLoadingProxies();
});

builder.Services.AddScoped(typeof(ICrudRepository<>), typeof(CrudRepository<>));

builder.Services.AddScoped<IAthleteService, AthleteService>();
builder.Services.AddScoped<ISportService, SportService>();// Add this line
builder.Services.AddScoped<ITournamentService, TournamentService>();// Add this line
builder.Services.AddScoped<IAthleteSportTournamentsService, AthleteSportTournamentsService>();// Add this line
builder.Services.AddAutoMapper(typeof(Program).Assembly);

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
