using DefeatYourOpponent.Domain.Repositories;
using DefeatYourOpponent.UI.Components;
using RiotApiController.Domain;
using RiotApiController.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var settingFileRepository = Factories.CreateSettingFileRepository();
Shared.SettingEntity = settingFileRepository.GetEntity();

builder.Services.AddSingleton(Factories.CreateGameResultRepository());

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

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
