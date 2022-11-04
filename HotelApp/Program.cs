using Business.ServicesDemo;
using Business.ServicesDemo.Bases;
using DataAccess.Contexts;
using DataAccess.Services;
using DataAccess.Services.Bases;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

#region Localization
List<CultureInfo> cultures = new List<CultureInfo>()
{
    new CultureInfo("en-US")
};

#endregion

builder.Services.AddControllersWithViews().AddJsonOptions(x =>
x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(c =>
{
    c.LoginPath = "/Accounts/Home/Login";
    c.AccessDeniedPath = "/Accounts/Home/AccessDenied";
    c.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    c.SlidingExpiration = true;
});

#region IoC Container (Inversion of Control Container)
var connectionString = builder.Configuration.GetConnectionString("HotelAppDb");
builder.Services.AddDbContext<Db>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<HotelServiceBase, HotelService>();
builder.Services.AddScoped<CityServiceBase, CityService>();
builder.Services.AddScoped<CountryServiceBase, CountryService>();
builder.Services.AddScoped<RoomServiceBase, RoomService>();
builder.Services.AddScoped<CustomerServiceBase, CustomerService>();
builder.Services.AddScoped<UserServiceBase, UserService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<RoleServiceBase, RoleService>();

#endregion

var app = builder.Build();

#region Localization
app.UseRequestLocalization(new RequestLocalizationOptions()
{
    DefaultRequestCulture = new RequestCulture(cultures.FirstOrDefault().Name),
    SupportedCultures = cultures,
    SupportedUICultures = cultures,
});
#endregion

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


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "welcome",
      pattern: "Home/Index"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
