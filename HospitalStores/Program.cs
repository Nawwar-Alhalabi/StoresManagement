using Microsoft.EntityFrameworkCore;
using Store_Bl.BL;
using Store_Bl.Models;
using StoreAdministration.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("constr")));
builder.Services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(180)); // Set session timeout

builder.Services.AddScoped<ClsStore>();
builder.Services.AddScoped<ClsDepartmentOrderForm>();
builder.Services.AddScoped<ClsPurchaseOrderForm>();
builder.Services.AddScoped<ClsReceiptForm>();
builder.Services.AddScoped<ClsReport>();
builder.Services.AddScoped<ClsDeliveryForm>();
builder.Services.AddScoped<ClsUser>();
builder.Services.AddScoped<ClsMedicalDepartment>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSession(); // Enable session middleware
app.UseExceptionHandler("/Home/Error");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
