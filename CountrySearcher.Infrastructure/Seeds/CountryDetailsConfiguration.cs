using CountrySearcher.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CountrySearcher.Infrastructure.Seeds
{
    public class CountryDetailsConfiguration : IEntityTypeConfiguration<CountryDetail>
    {
        public void Configure(EntityTypeBuilder<CountryDetail> builder)
        {
            builder.HasData(
                new CountryDetail
                {
                    Id = 1,
                    CountryId = 1,
                    Operator = "MTN Nigeria",
                    OperatorCode = "MTN NG"
                },
                new CountryDetail
                {
                    Id = 2,
                    CountryId = 1,
                    Operator = "Airtel Nigeria",
                    OperatorCode = "ANG"
                },
                new CountryDetail
                {
                    Id = 3,
                    CountryId = 1,
                    Operator = "9 Mobile Nigeria",
                    OperatorCode = "ETN"
                },
                new CountryDetail
                {
                    Id = 4,
                    CountryId = 1,
                    Operator = "Globacom Nigeria",
                    OperatorCode = "GLO"
                },
                new CountryDetail
                {
                    Id = 5,
                    CountryId = 2,
                    Operator = "Vodafone Ghana",
                    OperatorCode = "Vodafon GH"
                },
                new CountryDetail
                {
                    Id = 6,
                    CountryId = 2,
                    Operator = "MTN Ghana",
                    OperatorCode = "MTN Ghana"
                },
                new CountryDetail
                {
                    Id = 7,
                    CountryId = 2,
                    Operator = "Tigo Ghana",
                    OperatorCode = "Tigo Ghana"
                },
                new CountryDetail
                {
                    Id = 8,
                    CountryId = 3,
                    Operator = "MTN Benin",
                    OperatorCode = "MTN Benin"
                },
                new CountryDetail
                {
                    Id = 9,
                    CountryId = 3,
                    Operator = "Moov Benin",
                    OperatorCode = "Moov Benin"
                },
                new CountryDetail
                {
                    Id = 10,
                    CountryId = 4,
                    Operator = "MTN Cote d'Ivoire",
                    OperatorCode = "MTN CIV"
                });
        }
    }
}
