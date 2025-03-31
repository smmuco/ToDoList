using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Core.Interfaces;
using ToDoList.Core.Repositories;

var builder = WebApplication.CreateBuilder(args);


// Add DbContext
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repository
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();
// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
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
