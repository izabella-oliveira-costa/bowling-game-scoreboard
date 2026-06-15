using BowlingGameScoreboard.Models;
using BowlingGameScoreboard.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<BowlingService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/api/bowling/score", (ScoreRequest request, BowlingService service) =>
{
    var score = service.Calculate(request.Rolls);

    return Results.Ok(new ScoreResponse { Score = score });
});

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Add($"http://0.0.0.0:{port}");

app.Run();