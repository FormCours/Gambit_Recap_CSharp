using Demo_06_IntroASP.Services;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add demo service
builder.Services.AddSingleton<SingletonService>();
builder.Services.AddScoped<ScopedService>();
builder.Services.AddTransient<TransientService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Use(async (context, next) =>
{
    // Traitement du middleware

    // - Debut
    string? req = context.Request.Path.Value;
    Stopwatch sw = new Stopwatch();

    Console.WriteLine($"Start request : {req}");
    sw.Start();

    // - On passe la main au middleware suivante
    await next(context);

    // - Fin
    sw.Stop();
    Console.WriteLine($"End request : {req} {sw.ElapsedTicks}");
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
