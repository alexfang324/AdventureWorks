using AdventureWorks.EfModels;
using AdventureWorks.Interfaces;
using AdventureWorks.Respositories;
using AdventureWorks.ViewModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var sqLiteConnection = builder.Configuration.GetConnectionString("sqLiteConnection") ??
    throw new InvalidOperationException("Connection string 'sqLiteConnection' not found.");
builder.Services.AddDbContext<AdventureWorksContext>(options =>
    options.UseSqlite(sqLiteConnection));

builder.Services.AddScoped<IRepository<ProductVM>, ProductRepository>();
builder.Services.AddScoped<IRepository<ProductCategoryVM>, ProductCategoryRepository>();


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
