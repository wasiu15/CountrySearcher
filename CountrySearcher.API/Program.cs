using CountrySearcher.Application.Services;
using CountrySearcher.Domain.Interfaces.Repository;
using CountrySearcher.Domain.Interfaces.Services;
using CountrySearcher.Infrastructure.Data;
using CountrySearcher.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CountrySearcher.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;
            var dbConnection = configuration.GetConnectionString("SQLITE_CONNECTION");

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Use Serilog for logging
            builder.Services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();  // Remove other providers
                loggingBuilder.AddSerilog();
            });

            // Register services
            builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
            builder.Services.AddScoped<ICountryService, CountryService>();

            // Add DbContext with SQLite
            builder.Services.AddDbContext<CountrySearcherDbContext>(options => options.UseSqlite(dbConnection));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            // Map controllers
            app.MapControllers();

            // Ensure the database is updated
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<CountrySearcherDbContext>();
                dbContext.Database.Migrate();
                // You can also add database seeding logic here if needed
            }

            app.Run();
        }
    }
}
