
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using GwiNews.Application.Interfaces;
using GwiNews.Application.Services;
using GwiNews.Domain.Interfaces;
using GwiNews.Infra.Data.Repositories;
using GwiNews.Infra.IoC;
using Serilog;
using System.Text.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

        try
        {
            Log.Information("Starting up");

            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog();

            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddInfrastructureJWT(builder.Configuration);
            builder.Services.AddInfrastructureSwagger();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowAll", builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            builder.Services.AddControllers();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseSerilogRequestLogging(); // Add Serilog request logging

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application start-up failed");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}

