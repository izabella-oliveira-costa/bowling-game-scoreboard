using BowlingGameScoreboard.Services;
using BowlingGameScoreboard.Models;
using BowlingGameScoreboard.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<BowlingService>();

builder.Services.AddCors();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(policy =>
    policy.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader()
);

app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        context.Response.ContentType = "application/json";

        var exception = context.Features
            .Get<IExceptionHandlerFeature>()?
            .Error;

        context.Response.StatusCode = exception switch
        {
            InvalidRollException => 400,
            InvalidGameException => 422,
            _ => 500
        };

        var message = exception?.Message ?? "Unexpected server error";

        await context.Response.WriteAsJsonAsync(new ApiResponse<object>
        {
            Success = false,
            Message = message,
            Data = null
        });
    });
});

app.MapControllers();

app.Run();