using CountrySearcher.Domain.Dtos;
using CountrySearcher.Domain.Interfaces.Repository;
using CountrySearcher.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace CountrySearcher.Application.Services
{
    /// <summary>
    /// Service for retrieving country information based on phone numbers.
    /// </summary>
    public class CountryService : ICountryService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILogger<CountryService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryService"/> class.
        /// </summary>
        /// <param name="repositoryManager">The repository manager providing access to data.</param>
        /// <param name="logger">The logger for logging messages.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="repositoryManager"/> or <paramref name="logger"/> is null.</exception>
        public CountryService(IRepositoryManager repositoryManager, ILogger<CountryService> logger)
        {
            _repositoryManager = repositoryManager ?? throw new ArgumentNullException(nameof(repositoryManager));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Retrieves country information based on the provided phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number to look up.</param>
        /// <returns>A response containing the input number and corresponding country information.</returns>
        public async Task<CountryResponse> GetCountryByPhoneAsync(string phoneNumber)
        {
            try
            {
                // Check if the phone number is valid in terms of format and length
                if (!IsValidPhoneNumber(phoneNumber) || !IsValidLength(phoneNumber))
                {
                    _logger.LogInformation($"Invalid phone number format or length: {phoneNumber}");
                    return new CountryResponse
                    {
                        number = phoneNumber,
                        Country = null
                    };
                }

                // Extract the country code from the phone number
                var countryCode = phoneNumber.Substring(0, 3);

                // Retrieve country information from the repository based on the country code
                var countryFromDb = await _repositoryManager.CountryRepository.GetCountryByCodeAsync(countryCode);

                // Create and return the response
                return new CountryResponse
                {
                    number = phoneNumber,
                    Country = countryFromDb
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while processing phone number: {phoneNumber}");
                return new CountryResponse
                {
                    number = phoneNumber,
                    Country = null
                };
            }
        }

        /// <summary>
        /// Checks if the provided input is a valid phone number.
        /// </summary>
        /// <param name="input">The input to validate.</param>
        /// <returns>True if the input is a valid phone number; otherwise, false.</returns>
        private static bool IsValidPhoneNumber(string input)
        {
            return long.TryParse(input, out _);
        }

        /// <summary>
        /// Checks if the length of the provided phone number is within a valid range.
        /// </summary>
        /// <param name="input">The phone number to check.</param>
        /// <returns>True if the length is valid; otherwise, false.</returns>
        private static bool IsValidLength(string input)
        {
            return input.Length > 10 && input.Length < 14;
        }
    }
}