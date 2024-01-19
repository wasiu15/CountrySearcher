using CountrySearcher.Domain.Entities;
using CountrySearcher.Domain.Interfaces.Repository;
using CountrySearcher.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CountrySearcher.Infrastructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly CountrySearcherDbContext _dbContext;
        private readonly ILogger<CountryRepository> _logger;

        public CountryRepository(CountrySearcherDbContext dbContext, ILogger<CountryRepository> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Retrieves a country by its country code.
        /// </summary>
        /// <param name="countryCode">The country code to search for.</param>
        /// <returns>The country entity or null if not found.</returns>
        public async Task<Country> GetCountryByCodeAsync(string countryCode)
        {
            try
            {
                return await _dbContext.Countrys
                    .Where(country => country.CountryCode == countryCode)
                    .Include(country => country.CountryDetails)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, $"Error retrieving country with code {countryCode}");
                return null;
            }
        }
    }
}
