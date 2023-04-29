using Microsoft.EntityFrameworkCore;
using P2_2020GG602_2020SM602_2020ML601.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<hospitalDbContext>(opt =>
        opt.UseSqlServer(
            builder.Configuration.GetConnectionString("hospitalDbConnection")
            )
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=registro}/{action=Index}/{id?}");

app.Run();
