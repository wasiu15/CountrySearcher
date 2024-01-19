using CountrySearcher.Domain.Dtos;

namespace CountrySearcher.Domain.Interfaces.Services
{
    public interface ICountryService
    {
        Task<CountryResponse> GetCountryByPhoneAsync(string phoneNumber);
    }
}
