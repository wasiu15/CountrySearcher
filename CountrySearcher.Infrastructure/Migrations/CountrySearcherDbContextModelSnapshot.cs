﻿// <auto-generated />
using CountrySearcher.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CountrySearcher.Infrastructure.Migrations
{
    [DbContext(typeof(CountrySearcherDbContext))]
    partial class CountrySearcherDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.15");

            modelBuilder.Entity("CountrySearcher.Domain.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CountryIso")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Countrys");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryCode = "234",
                            CountryIso = "NG",
                            Name = "Nigeria"
                        },
                        new
                        {
                            Id = 2,
                            CountryCode = "233",
                            CountryIso = "GH",
                            Name = "Ghana"
                        },
                        new
                        {
                            Id = 3,
                            CountryCode = "229",
                            CountryIso = "BN",
                            Name = "Benin Republic"
                        },
                        new
                        {
                            Id = 4,
                            CountryCode = "225",
                            CountryIso = "CIV",
                            Name = "Cote d'Ivoire"
                        });
                });

            modelBuilder.Entity("CountrySearcher.Domain.Entities.CountryDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Operator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OperatorCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("CountryDetails");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Operator = "MTN Nigeria",
                            OperatorCode = "MTN NG"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            Operator = "Airtel Nigeria",
                            OperatorCode = "ANG"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 1,
                            Operator = "9 Mobile Nigeria",
                            OperatorCode = "ETN"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 1,
                            Operator = "Globacom Nigeria",
                            OperatorCode = "GLO"
                        },
                        new
                        {
                            Id = 5,
                            CountryId = 2,
                            Operator = "Vodafone Ghana",
                            OperatorCode = "Vodafon GH"
                        },
                        new
                        {
                            Id = 6,
                            CountryId = 2,
                            Operator = "MTN Ghana",
                            OperatorCode = "MTN Ghana"
                        },
                        new
                        {
                            Id = 7,
                            CountryId = 2,
                            Operator = "Tigo Ghana",
                            OperatorCode = "Tigo Ghana"
                        },
                        new
                        {
                            Id = 8,
                            CountryId = 3,
                            Operator = "MTN Benin",
                            OperatorCode = "MTN Benin"
                        },
                        new
                        {
                            Id = 9,
                            CountryId = 3,
                            Operator = "Moov Benin",
                            OperatorCode = "Moov Benin"
                        },
                        new
                        {
                            Id = 10,
                            CountryId = 4,
                            Operator = "MTN Cote d'Ivoire",
                            OperatorCode = "MTN CIV"
                        });
                });

            modelBuilder.Entity("CountrySearcher.Domain.Entities.CountryDetail", b =>
                {
                    b.HasOne("CountrySearcher.Domain.Entities.Country", "Country")
                        .WithMany("CountryDetails")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("CountrySearcher.Domain.Entities.Country", b =>
                {
                    b.Navigation("CountryDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
