using GestionPanier.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Mycontext>(opt => opt.UseSqlServer(@"Data source=DESKTOP-1H37APJ\SQLSERVER;initial catalog=GestionPanier;integrated security=true;Encrypt=false"));
builder.Services.AddSession(opt => {  
                                  opt.Cookie.Name = ".YourApp.Session";
                                  opt.IdleTimeout = TimeSpan.FromHours(10); 
                                  opt.Cookie.HttpOnly = true;
                                  opt.Cookie.IsEssential = true; 
                                    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Create}/{id?}");

app.Run();
