using CountrySearcher.Domain.Entities;

namespace CountrySearcher.Domain.Dtos
{
    public class CountryResponse
    {
        public string number { get; set; }
        public Country Country { get; set; }
    }
}
