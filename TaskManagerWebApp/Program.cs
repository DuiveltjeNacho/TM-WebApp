using TaskManagerWebApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddScoped<TaskManager>();

var dbPath = Environment.GetEnvironmentVariable("DATABASE_PATH") ?? "/app/data/taskmanager.db";
Directory.CreateDirectory(Path.GetDirectoryName(dbPath)); // Ensure directory exists

builder.Services.AddDbContext<TaskManagerDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
