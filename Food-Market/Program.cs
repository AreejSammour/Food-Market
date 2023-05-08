using Food_Market;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationContext") ?? throw new InvalidOperationException("Connection string 'ApplicationContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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

