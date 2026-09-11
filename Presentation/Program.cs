using Presentation.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuration: Python API base URL (appsettings.Development.json or environment variables)
var pythonBaseUrl = builder.Configuration["PythonApi:BaseUrl"] ?? "http://localhost:8000";

// Use a local in-process implementation instead of an external Python API
builder.Services.AddSingleton<IPythonApiClient, LocalApiClient>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Revision}/{action=Index}/{id?}");

app.Run();
