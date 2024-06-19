using DefeatYourOpponent.Domain;
using DefeatYourOpponent.Infrastructure;
using DefeatYourOpponent.UI.Components;
using DefeatYourOpponent.UI.ViewModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

Shared.SettingEntity = Factories.CreateSettingFileRepository().GetEntity();

var apiKey = "RGAPI-a802e21f-6407-4722-b20a-00e6dae736d8";

builder.Services.AddSingleton(Factories.CreateApiRepository(apiKey));
builder.Services.AddSingleton(
    Factories.CreateErrorMessageConverterRespository(
        Shared.SettingEntity.RiotApiErrorMessageListFilePath, Shared.SettingEntity.InternalErrorMessageListFilePath));

builder.Services.AddScoped<MatchIndexViewModel>();
builder.Services.AddTransient<MatchDetailViewModel>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
