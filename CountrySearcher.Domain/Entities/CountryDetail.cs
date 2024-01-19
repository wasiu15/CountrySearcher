using System.Text.Json.Serialization;

namespace CountrySearcher.Domain.Entities
{
    public class CountryDetail
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        [JsonIgnore]
        public Country Country { get; set; }
        public string Operator { get; set; }
        public string OperatorCode { get; set; }
    }
}
