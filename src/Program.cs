using BlazorServerSignalRApp.BackgroundServices;
using BlazorServerSignalRApp.Data;
using BlazorServerSignalRApp.Extensions;
using BlazorServerSignalRApp.Hubs;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

#region snippet_ConfigureServices
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddResponseCompression(opts =>
{
	opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
		new[] { "application/octet-stream" });
});
builder.Services.AddSignalR();
builder.Services.AddMongoDatabase(builder.Configuration);
builder.Services.AddHostedService<ParcelInfoChangeWatcherBackgroundService>();
#endregion

var app = builder.Build();

#region snippet_Configure
app.UseResponseCompression();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapHub<ParcelInfoHub>("/parcel-info-hub");
app.MapFallbackToPage("/_Host");

app.Run();
#endregion

