using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<CalendarWebApp.Client.Services.CalendarService>();

await builder.Build().RunAsync();
