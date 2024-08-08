using Momentum.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Persistence layer service registration
builder.Services.AddPersistenceServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "dashboard",
    pattern: "admin/{controller=Dashboard}/{action=Index}/{id?}"
);

app.Run();