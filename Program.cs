using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using University.DAL;
using University.DAL.Repositories;
using University.DAL.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<UniversityDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<IStudRepository, StudRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<AnalyticModuleRepo>();

builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddOpenApiDocument

// Add services to the container.
builder.Services.AddControllersWithViews();

void conneñtion(SqlServerDbContextOptionsBuilder builder)
{
    throw new NotImplementedException();
}

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
