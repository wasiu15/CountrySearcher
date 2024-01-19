using CountrySearcher.Domain.Dtos;
using CountrySearcher.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CountrySearcher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly ILogger<CountryController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryController"/> class.
        /// </summary>
        /// <param name="countryService">The country service for retrieving country information.</param>
        /// <param name="logger">The logger for logging messages.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="countryService"/> or <paramref name="logger"/> is null.</exception>
        public CountryController(ICountryService countryService, ILogger<CountryController> logger)
        {
            _countryService = countryService ?? throw new ArgumentNullException(nameof(countryService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Retrieves country information based on the provided phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number to look up.</param>
        /// <returns>Action result containing the country information or an error response.</returns>
        [HttpGet("GetCountryByPhone")]
        [ProducesResponseType(typeof(CountryResponse), 200)]
        public async Task<ActionResult> GetCountryByPhone(string phoneNumber)
        {
            try
            {
                // Log the incoming request with the phone number
                _logger.LogInformation($"Received request for phone number: {phoneNumber}");

                // Call the country service to get country information
                var countryResult = await _countryService.GetCountryByPhoneAsync(phoneNumber);

                // Log the result of the operation
                _logger.LogInformation($"Country information retrieved for phone number: {phoneNumber}");

                // Return the result as an OK response
                return Ok(countryResult);
            }
            catch (Exception ex)
            {
                // Log any exceptions that occur during the operation
                _logger.LogError(ex, $"Error processing request for phone number: {phoneNumber}");

                // Return an error response
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }
    }
}
