using Microsoft.EntityFrameworkCore;
using MVC.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StudentDBContext>(option =>
{
    option.UseNpgsql(builder.Configuration.GetConnectionString("DafaultConnection"));
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); // MIDDLEWARE
app.UseStaticFiles();      // MIDDLEWARE

app.UseRouting();          // MIDDLEWARE

app.UseAuthorization();    // MIDDLEWARE

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); //onvention based Routing

 app.Run();
