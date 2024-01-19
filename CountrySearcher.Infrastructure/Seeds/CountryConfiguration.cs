using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CountrySearcher.Domain.Entities;

namespace CountrySearcher.Infrastructure.Seeds
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                new Country
                {
                    Id = 1,
                    CountryCode = "234",
                    Name = "Nigeria",
                    CountryIso = "NG"
                },
                new Country
                {
                    Id = 2,
                    Name = "Ghana",
                    CountryCode = "233",
                    CountryIso = "GH"
                },
                new Country
                {
                    Id = 3,
                    CountryCode = "229",
                    Name = "Benin Republic",
                    CountryIso = "BN"
                },
                new Country
                {
                    Id = 4,
                    Name = "Cote d'Ivoire",
                    CountryCode = "225",
                    CountryIso = "CIV"
                });
        }
    }
}
