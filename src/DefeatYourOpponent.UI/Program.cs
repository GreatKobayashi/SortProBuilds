using DefeatYourOpponent.Domain;
using DefeatYourOpponent.Infrastructure;
using DefeatYourOpponent.UI.Components;
using DefeatYourOpponent.UI.ViewModel;
using Microsoft.AspNetCore.HttpOverrides;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.KnownProxies.Add(IPAddress.Parse("10.0.0.100"));
});

Shared.SettingEntity = Factories.CreateSettingFileRepository().GetEntity();

var apiKeyRepository = Factories.CreateApiKeyRepository(Shared.SettingEntity.ApiKeyFilePath);
var apiKey = await apiKeyRepository.GetApiKey();

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
    //app.UseHsts();
    //app.UseHttpsRedirection();
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
