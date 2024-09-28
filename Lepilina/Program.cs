using Lepilina;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var app = builder.Build();

app.UseMiddleware<Tem>();

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

app.Run();