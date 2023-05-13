using AlloServicePFA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity.UI;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyContext>(opt =>
{
    opt.UseSqlServer(@"Data Source=.\SQLEXPRESS;Encrypt=false;initial catalog=alloservicepfa; integrated security=true");
});
builder.Services.AddSession(opt =>
{
    opt.Cookie.Name = ".AdventureWorks.Session";
    opt.IdleTimeout = TimeSpan.FromDays(1);
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
app.UseAuthorization();
app.UseAuthentication();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();