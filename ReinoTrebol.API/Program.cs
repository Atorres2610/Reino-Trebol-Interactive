using Microsoft.AspNetCore.Mvc;
using ReinoTrebol.API.Filters;
using ReinoTrebol.Infrastructure;
using ReinoTrebol.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
string corsNamePolicy = "ApiCorsPolicy";

builder.Services.AddControllers();
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddInfrastructure(configuration)
    .AddTransient<DataSeed>()
    .AddScoped<ValidateRequestFilter>()
    //Suprimir la validación por defecto
    .Configure<ApiBehaviorOptions>(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    })
    .AddCors(x =>
    {
        x.AddPolicy(corsNamePolicy, policy =>
        {
            policy.WithOrigins(configuration["Web:UrlHttps"]!, configuration["Web:UrlHttp"]!).AllowAnyMethod().AllowAnyHeader();
        });
    });

var app = builder.Build();

//Crea
using (var scope = app.Services.CreateScope())
{
    DataSeed dataSeed = scope.ServiceProvider.GetRequiredService<DataSeed>();
    dataSeed.SeedAsync().Wait();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection()
    .UseCors(corsNamePolicy)
    .UseAuthorization();

app.MapControllers();

app.Run();