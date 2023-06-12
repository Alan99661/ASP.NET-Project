using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VideoGameApplication.Database;
using VideoGameApplication.Servises.Contracts.CrudOperations;
using VideoGameApplication.Servises.Contracts.Other;
using VideoGameApplication.Servises.Contracts.UpdateModelGet;
using VideoGameApplication.Servises.CrudOperations;
using VideoGameApplication.Servises.MapConfig;
using VideoGameApplication.Servises.OtherOperations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<VideoGameDBContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(typeof(MapConfiguration));
builder.Services.AddScoped<IDeveloperCrudOperations, DeveloperCrudOperations>();
builder.Services.AddScoped<IGameCrudOperations, GameCrudOperations>();
builder.Services.AddScoped<IPlatformCrudOperations, PlatformCrudOperations>();
builder.Services.AddScoped<IReviewCrudOperations, ReviewCrudOperations>();
builder.Services.AddScoped<IScreenshotCrudOperations, ScreenshotCrudOperations>();
builder.Services.AddScoped<IGenreCrudOperations, GenreCrudOperations>();
builder.Services.AddScoped<IGetUpdateModels, GetUpdateModels>();
builder.Services.AddScoped<IGetSelectModels, GetSelectModels>();


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
