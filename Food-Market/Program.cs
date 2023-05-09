using Food_Market;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationContext") ?? throw new InvalidOperationException("Connection string 'Moawia' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
var app = builder.Build();

//Products data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// map routing for tickets
app.MapControllerRoute(
    name: "EditTicket",
    pattern: "Ticket/edit",
    defaults: new { controller = "Ticket", action = "Edit" });

app.MapControllerRoute(
    name: "EditTicketWithQuery",
    pattern: "Ticket/edit/",
    defaults: new { controller = "Ticket", action = "Edit" });

app.MapControllerRoute(
    name: "DeleteConfirmation",
    pattern: "Ticket/DeleteConfirmation",
    defaults: new { controller = "Ticket", action = "DeleteConfirmation" });

app.Run();

