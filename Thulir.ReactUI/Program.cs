using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Thulir.Core.Dals;
using Thulir.Core.Models;
using Thulir.Core.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseStaticFiles();
app.UseRouting();

if (!app.Environment.IsDevelopment())
{
    app.UseStaticFiles(new StaticFileOptions()
    {
        FileProvider = new PhysicalFileProvider("/data/landsat-tiles"),
        RequestPath = new PathString("/landsat-tile")
    });
}

app.MapControllerRoute(
    "default",
    "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

await ConfigLoader.GetInstance().Init();
ThulirGlobals globals = await ConfigLoader.GetInstance().GetGlobals();

PostgresDal.Init(new PostgresConfig(
    globals.PostgresHost,
    globals.PostgresUserName,
    globals.PostgresPassword,
    globals.PostgresDatabase)
);

app.Run();
