﻿// <auto-generated />
using System;
using Flag_Explorer_App.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Flag_Explorer_App.Migrations
{
    [DbContext(typeof(FlagExplorerDbContext))]
    partial class FlagExplorerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            modelBuilder.Entity("Flag_Explorer_App.Domain.Entities.Country.CountryDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Alpha2Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Alpha3Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CommonName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OfficialName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Population")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("CountryDetail");
                });

            modelBuilder.Entity("Flag_Explorer_App.Domain.Entities.Country.CountryFlag", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CountryDetailId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("FlagCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Png")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Svg")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CountryDetailId");

                    b.ToTable("CountryFlag");
                });

            modelBuilder.Entity("Flag_Explorer_App.Domain.Entities.Country.CountryLocation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.PrimitiveCollection<string>("Capital")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CountryDetailId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SubRegion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CountryDetailId");

                    b.ToTable("CountryLocations");
                });

            modelBuilder.Entity("Flag_Explorer_App.Domain.Entities.Country.Maps", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CountryLocationId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("GoogleMaps")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OpenStreetMaps")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CountryLocationId")
                        .IsUnique();

                    b.ToTable("Maps");
                });

            modelBuilder.Entity("Flag_Explorer_App.Domain.Entities.Country.CountryFlag", b =>
                {
                    b.HasOne("Flag_Explorer_App.Domain.Entities.Country.CountryDetail", "CountryDetail")
                        .WithMany()
                        .HasForeignKey("CountryDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CountryDetail");
                });

            modelBuilder.Entity("Flag_Explorer_App.Domain.Entities.Country.CountryLocation", b =>
                {
                    b.HasOne("Flag_Explorer_App.Domain.Entities.Country.CountryDetail", "CountryDetail")
                        .WithMany()
                        .HasForeignKey("CountryDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CountryDetail");
                });

            modelBuilder.Entity("Flag_Explorer_App.Domain.Entities.Country.Maps", b =>
                {
                    b.HasOne("Flag_Explorer_App.Domain.Entities.Country.CountryLocation", "CountryLocation")
                        .WithOne("MapAddresses")
                        .HasForeignKey("Flag_Explorer_App.Domain.Entities.Country.Maps", "CountryLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CountryLocation");
                });

            modelBuilder.Entity("Flag_Explorer_App.Domain.Entities.Country.CountryLocation", b =>
                {
                    b.Navigation("MapAddresses")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
