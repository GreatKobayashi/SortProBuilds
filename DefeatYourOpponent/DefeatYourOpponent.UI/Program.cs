using DefeatYourOpponent.Domain;
using DefeatYourOpponent.Infrastructure;
using DefeatYourOpponent.UI.Components;
using DefeatYourOpponent.UI.ViewModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

Shared.SettingEntity = Factories.CreateSettingFileRepository().GetEntity();

builder.Services.AddSingleton(Factories.CreateGameResultRepository());
builder.Services.AddSingleton(Factories.CreateTimeTineRepository());
builder.Services.AddSingleton(
    Factories.CreateErrorMessageConverterRespository(
        Shared.SettingEntity.RiotApiErrorMessageListFilePath, Shared.SettingEntity.InternalErrorMessageListFilePath));
builder.Services.AddSingleton(Factories.CreateChampionsDataRepository(Shared.SettingEntity.ChampionsDataFilePath).GetEntity());
builder.Services.AddSingleton(Factories.CreateRiotDataConverterRepository(Shared.SettingEntity.QueueTypeListFilePath));

builder.Services.AddScoped<GameResultIndexViewModel>();
builder.Services.AddScoped<GameDetailViewModel>();

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
