using Microsoft.AspNetCore.Identity;
using Momentum.Domain.Entities;
using Momentum.Persistence;
using Momentum.Persistence.ApplicationDbContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Persistence layer service registration
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<MomentumDbContext>().AddDefaultTokenProviders();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "dashboard",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}"
);

app.Run();