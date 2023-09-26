using AspNetCoreMvc_Proje_DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using AspNetCoreMvc_Proje_Service.Extensions;
using System.Reflection;
using AspNetCoreMvc_Proje_DataAccess.Repositories;
using AspNetCoreMvc_Proje_Entity.Interfaces;
using AspNetCoreMvc_Proje_Service.Manager;
using AspNetCoreMvc_Proje_Entity.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ECommerceDbContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

builder.Services.ScopeExtensions();

builder.Services.AddSession(
	options => options.IdleTimeout = TimeSpan.FromMinutes(120) 
	);

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AnaSayfa}/{action=Index}/{id?}");

app.Run();
