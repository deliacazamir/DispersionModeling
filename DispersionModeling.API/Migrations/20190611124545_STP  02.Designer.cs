﻿// <auto-generated />
using System;
using DispersionModeling.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DispersionModeling.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190611124545_STP  02")]
    partial class STP02
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DispersionModeling.API.Models.DispersionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AirTemperature");

                    b.Property<double>("AtmosphericConditions");

                    b.Property<double>("CloudCoverage");

                    b.Property<DateTime>("CurrentDate");

                    b.Property<double>("EmissionOfPollutantsConcentration");

                    b.Property<double>("ExitTemperature");

                    b.Property<double>("MaxDistance");

                    b.Property<double>("SmokeExitSpeed");

                    b.Property<double>("SolarRadiations");

                    b.Property<string>("WindDirection");

                    b.Property<double>("WindSpeedAtTenMetters");

                    b.HasKey("Id");

                    b.ToTable("DispersionModels");
                });

            modelBuilder.Entity("DispersionModeling.API.Models.Form", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("SourceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("DispersionModeling.API.Models.GPSLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Altitude");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.HasKey("Id");

                    b.ToTable("GPSLocations");
                });

            modelBuilder.Entity("DispersionModeling.API.Models.Pollutant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ChemicalFormula");

                    b.Property<bool>("IsCarcinogenic");

                    b.Property<double>("LegislativeValue");

                    b.Property<string>("Name");

                    b.Property<string>("OrganicType");

                    b.Property<double>("SedimentationSpeed");

                    b.Property<string>("StateOfAggregation");

                    b.Property<string>("Unit");

                    b.HasKey("Id");

                    b.ToTable("Pollutants");
                });

            modelBuilder.Entity("DispersionModeling.API.Models.PollutionSource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Altitude");

                    b.Property<double>("ChimneyDiameter");

                    b.Property<double>("ChimneyHeight");

                    b.Property<string>("Description");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name");

                    b.Property<string>("TerrainType");

                    b.HasKey("Id");

                    b.ToTable("PollutionSources");
                });

            modelBuilder.Entity("DispersionModeling.API.Models.StationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("StationTypes");
                });

            modelBuilder.Entity("DispersionModeling.API.Models.StationTypePollutant", b =>
                {
                    b.Property<int>("PollutantID");

                    b.Property<int>("StationTypeID");

                    b.HasKey("PollutantID", "StationTypeID");

                    b.HasIndex("StationTypeID");

                    b.ToTable("StationTypePollutant");
                });

            modelBuilder.Entity("DispersionModeling.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DispersionModeling.API.Models.StationTypePollutant", b =>
                {
                    b.HasOne("DispersionModeling.API.Models.Pollutant", "Pollutant")
                        .WithMany()
                        .HasForeignKey("PollutantID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DispersionModeling.API.Models.StationType", "StationType")
                        .WithMany()
                        .HasForeignKey("StationTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
