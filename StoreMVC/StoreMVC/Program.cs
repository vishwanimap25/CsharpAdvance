using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StoreMVC.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDBcontext>(options =>
{
    var newBuild = builder.Configuration.GetConnectionString("dbcs");
    options.UseSqlServer(newBuild);
});

//Add Authentication
builder.Services.AddAuthentication("awaleCookie").AddCookie("awaleCookie", Options =>
{
    Options.LoginPath = "/User/Login";   //will be redirected here when autheticated
    Options.AccessDeniedPath = "/User/AccessDenied"; //optinal
});

//plan based authtication 
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Pro", policy =>
    {
        policy.RequireClaim("UserPlan", "Pro");
    });
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

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
