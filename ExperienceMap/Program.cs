using ExperienceMap.Components;
using ExperienceMap.Data;
using ExperienceMap.Data.Input;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorPages();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddAntDesign();

builder.Services.AddHttpClient();
builder.Services.AddSqlite<CourseContext>("Data Source=courses.db");
builder.Services.AddScoped<CourseService>();


//app.MapRazorComponents<App>()
//    .AddInteractiveWebAssemblyRenderMode();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.MapControllerRoute(
    name: "default", 
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

using (var scope = app.Services
    .GetRequiredService<IServiceScopeFactory>()
    .CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CourseContext>();
    //TextToCourse.ParseCourseText("MENV1100.txt");
    if (db.Database.EnsureCreated()){
        Seed.SeededInit(db);
    }
}

app.Run();
