using Microsoft.EntityFrameworkCore;
using ormApp.Models;
var builder = WebApplication.CreateBuilder(args);

// Додайте служби до контейнера.
builder.Services.AddControllersWithViews();

// Add DbContext with MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21))));

var app = builder.Build();

// Налаштуйте конвеєр HTTP запитів.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "users",
    pattern: "{controller=Users}/{action=Index}/{id?}");

app.Run();
