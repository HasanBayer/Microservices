using FluentValidation;
using FluentValidation.AspNetCore;
using FreeCourse.Shared.Services;
using FreeCourse.Web.Extensions;
using FreeCourse.Web.Handler;
using FreeCourse.Web.Helpers;
using FreeCourse.Web.Models;
using FreeCourse.Web.Services;
using FreeCourse.Web.Services.Interfaces;
using FreeCourse.Web.Validators;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAccessTokenManagement();
builder.Services.AddSingleton<PhotoHelper>();
builder.Services.AddScoped<ResourceOwnerPasswordTokenHandler>();
builder.Services.AddScoped<ClientCredentialTokenHandler>();
builder.Services.AddScoped<ISharedIdentityService, SharedIdentityService>();

//builder.Services.AddHttpClient<IIdentityService, IdentityService>();
//builder.Services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();
//var serviceApiSettings = builder.Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

//builder.Services.AddHttpClient<IUserService, UserService>(opt =>
//{
//    opt.BaseAddress = new Uri(serviceApiSettings.BaseUrl);
//}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
//builder.Services.AddHttpClient<ICatalogService, CatalogService>(opt =>
//{
//    opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayUrl}/{serviceApiSettings.Catalog.Path}");
//}).AddHttpMessageHandler<ClientCredentialTokenHandler>();
//builder.Services.AddHttpClient<IPhotoStockService, PhotoStockService>(opt =>
//{
//    opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayUrl}/{serviceApiSettings.PhotoStock.Path}");
//}).AddHttpMessageHandler<ClientCredentialTokenHandler>();
//builder.Services.AddHttpClient<IBasketService, BasketService>(opt =>
//{
//    opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayUrl}/{serviceApiSettings.Basket.Path}");
//}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddValidatorsFromAssemblyContaining<CourseCreateInputValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CourseUpdateInputValidator>();



builder.Services.AddHttpClientServices(builder.Configuration);



builder.Services.Configure<ServiceApiSettings>(builder.Configuration.GetSection("ServiceApiSettings"));
builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection("ClientSettings"));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opts =>
{
    opts.LoginPath = "/Auth/SignIn";
    opts.ExpireTimeSpan = TimeSpan.FromDays(60);
    opts.SlidingExpiration = true;
    opts.Cookie.Name = "udemywebcookie";

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
