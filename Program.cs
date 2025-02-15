using Microsoft.EntityFrameworkCore;
using Mission06_DeMann.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MovieDbContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:MovieConnection"]);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
    
    app.UseExceptionHandler("/Home/Error");
app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();