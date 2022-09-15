using System.Text.Json.Serialization;
using Application;
using Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterServices();

var secretsPath = builder.Configuration.GetValue<string>("UserSecretsPath");

if (secretsPath is null)
{
    throw new ApplicationException("Unable to load path for secrets.json");
}

builder.Configuration.AddJsonFile(secretsPath);

var openWeatherMapConfig = new OpenWeatherMapConfig(new OpenWeatherMapToken(builder.Configuration.GetValue<string>("Authorization:OpenWeatherMapToken")));
builder.Services.AddSingleton(openWeatherMapConfig);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
