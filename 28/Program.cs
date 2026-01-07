using _28.Repositories.Abstractions;
using _28.Repositories.Context;
using _28.Repositories.Implementations;
using _28.Services.Abstractions;
using _28.Services.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Conexion a la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Inyeccion de dependencia
builder.Services.AddTransient<ITareaRepositories, TareaRepositories>();
builder.Services.AddTransient<ITareaServices, TareaServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    //Activar el uso de archivos estaticos en el ambiente de produccion
    app.UseStaticFiles();

    //Migracion para el ambiente de Produccion
    using var serviceScope = app.Services.CreateScope();
    using var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
    dbContext?.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
