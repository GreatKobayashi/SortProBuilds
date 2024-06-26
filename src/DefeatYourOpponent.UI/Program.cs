using DefeatYourOpponent.Domain;
using DefeatYourOpponent.Infrastructure;
using DefeatYourOpponent.UI.Components;
using DefeatYourOpponent.UI.ViewModel;
using Microsoft.AspNetCore.HttpOverrides;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.KnownProxies.Add(IPAddress.Parse("10.0.0.100"));
});

Shared.SettingEntity = Factories.CreateSettingFileRepository().GetEntity();

var apiKey = "RGAPI-a802e21f-6407-4722-b20a-00e6dae736d8";

builder.Services.AddSingleton(Factories.CreateApiRepository(apiKey));
builder.Services.AddSingleton(
    Factories.CreateErrorMessageConverterRespository(
        Shared.SettingEntity.RiotApiErrorMessageListFilePath, Shared.SettingEntity.InternalErrorMessageListFilePath));

builder.Services.AddScoped<MatchIndexViewModel>();
builder.Services.AddTransient<MatchDetailViewModel>();

builder.Services.AddAuthentication();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
    app.UseHttpsRedirection();
}

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.UseAuthentication();

app.Run();
