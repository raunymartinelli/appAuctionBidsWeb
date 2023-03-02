using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Assignment1.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Assignment1ContextConnection") ?? throw new InvalidOperationException("Connection string 'Assignment1ContextConnection' not found.");



builder.Services.AddDbContext<Assignment1Context>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Assignment1User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Assignment1Context>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
