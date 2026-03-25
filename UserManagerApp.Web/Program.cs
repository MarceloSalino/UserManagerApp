using Microsoft.EntityFrameworkCore;
using UserManagerApp.Application.Interfaces;
using UserManagerApp.Application.Services;
using UserManagerApp.Domain.Interfaces;
using UserManagerApp.Infrastructure.Data;
using UserManagerApp.Infrastructure.Repositories;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Error()
    .WriteTo.File(
        Path.Combine(AppContext.BaseDirectory, "logs/error-.txt"),
        rollingInterval: RollingInterval.Day
    )
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
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
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Index}/{id?}");


try
{
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Erro fatal na aplicação");
}
finally
{
    Log.CloseAndFlush(); 
}
