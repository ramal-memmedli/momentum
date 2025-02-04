using Microsoft.AspNetCore.Identity;
using Momentum.Domain.Entities;
using Momentum.Persistence;
using Momentum.Persistence.ApplicationDbContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<MomentumDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}else
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "momentum",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
);

app.Run();
