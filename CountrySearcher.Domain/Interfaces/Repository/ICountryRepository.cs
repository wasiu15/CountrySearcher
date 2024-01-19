using CountrySearcher.Domain.Entities;

namespace CountrySearcher.Domain.Interfaces.Repository
{
    public interface ICountryRepository
    {
        Task<Country> GetCountryByCodeAsync(string countryCode);
    }
}
