using Business.ServicesDemo;
using Business.ServicesDemo.Bases;
using DataAccess.Contexts;
using DataAccess.Services;
using DataAccess.Services.Bases;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region IoC Container (Inversion of Control Container)
var connectionString = builder.Configuration.GetConnectionString("HotelAppDb");
builder.Services.AddDbContext<Db>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<HotelServiceBase, HotelService>();
builder.Services.AddScoped<CityServiceBase, CityService>();
builder.Services.AddScoped<CountryServiceBase, CountryService>();
builder.Services.AddScoped<RoomServiceBase, RoomService>();
builder.Services.AddScoped<CustomerServiceBase, CustomerService>();




#endregion

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
