using RiotApiController.Domain;
using RiotApiController.Domain.Entities;
using RiotApiController.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(options =>
    options.Filters.Add<RiotApiResponseExceptionFilter>());

var app = builder.Build();

var settingFileRepository = Factories.CreateSettingFileRepository();
Shared.SettingEntity = settingFileRepository.GetEntity();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
