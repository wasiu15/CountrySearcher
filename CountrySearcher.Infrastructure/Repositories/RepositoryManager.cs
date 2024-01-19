using System;
using System.Threading.Tasks;
using CountrySearcher.Domain.Interfaces.Repository;
using CountrySearcher.Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace CountrySearcher.Infrastructure.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly CountrySearcherDbContext _repositoryContext;
        private readonly ILogger<CountryRepository> _countryLogger;
        private readonly Lazy<ICountryRepository> _countryRepository;

        public RepositoryManager(CountrySearcherDbContext repositoryContext, ILogger<CountryRepository> countryLogger)
        {
            _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
            _countryLogger = countryLogger ?? throw new ArgumentNullException(nameof(countryLogger));
            _countryRepository = new Lazy<ICountryRepository>(() => new CountryRepository(repositoryContext, countryLogger));
        }

        /// <summary>
        /// Gets the instance of the country repository.
        /// </summary>
        public ICountryRepository CountryRepository => _countryRepository.Value;

        /// <summary>
        /// Saves changes asynchronously to the underlying database.
        /// </summary>
        public async Task SaveAsync()
        {
            try
            {
                await _repositoryContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                _countryLogger.LogError(ex, "Error saving changes to the database");
            }
        }
    }
}
