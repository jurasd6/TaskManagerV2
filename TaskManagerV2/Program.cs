using Microsoft.EntityFrameworkCore;
using TaskManagerV2.Core.Interfaces;
using TaskManagerV2.Infrastructure.Persistence;
using TaskManagerV2.Infrastructure.Repositories;
using TaskManagerV2.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Connection string
//var conn = builder.Configuration.GetConnectionString("DefaultConnection");
var conn = "server=localhost;port=3306;database=taskmanagerdb;user=root;password=;";

//EF Core i MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(conn, new MySqlServerVersion(new Version(8, 0, 39))));

//Repo
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseAntiforgery();

// Mapowanie Blazora
app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();
