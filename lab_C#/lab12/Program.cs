using lab10_ASP.Context;
using lab10_ASP.ContextDataBase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ContextDBApp>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
// Add services to the container.
builder.Services.AddControllersWithViews();
string path = builder.Configuration.GetConnectionString("DefaultConnection");
// НАСТРОЙКА ПОДКЛЮЧЕНИЯ - берем строку из appsettings.json
builder.Services.AddDbContext<UniversityDbDormanchukContext>(options =>
    options.UseSqlServer(path)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Students}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();