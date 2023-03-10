using Microsoft.EntityFrameworkCore;

using Yatzy.Server.Database;
using Yatzy.Server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSpaYarp();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Default");
var version = new MariaDbServerVersion(new Version(10, 3));
builder.Services.AddDbContext<YatzyContext>(options => options.UseMySql(connectionString, version));

builder.Services.AddScoped<HighscoreService>();
builder.Services.AddScoped<PlayerService>();
builder.Services.AddScoped<ResultService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSpaYarp();
}

app.MapFallbackToFile("index.html");

app.Run();
