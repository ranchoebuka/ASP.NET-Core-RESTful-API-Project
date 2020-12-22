﻿// <auto-generated />
using System;
using EuropeLeagues.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EuropeLeagues.API.Migrations
{
    [DbContext(typeof(EuropeLeagueContext))]
    partial class EuropeLeagueContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("EuropeLeagues.API.Entities.FootballClub", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Honours")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LeagueId")
                        .HasColumnType("int");

                    b.Property<string>("ManagerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StadiumName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("stadiumCapacity")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.ToTable("Clubs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LeagueId = 1,
                            ManagerName = "Ole Gunnar Solskjaer",
                            Name = "Manchester United",
                            StadiumName = "Old Trafford",
                            stadiumCapacity = 75000.0
                        },
                        new
                        {
                            Id = 2,
                            LeagueId = 1,
                            ManagerName = "Frank Lampard",
                            Name = "Chelsea FC",
                            StadiumName = "Stamford Bridge",
                            stadiumCapacity = 40500.0
                        },
                        new
                        {
                            Id = 3,
                            LeagueId = 1,
                            ManagerName = "Pep Guardiola",
                            Name = "Manchester City",
                            StadiumName = "City of Manchester Stadium",
                            stadiumCapacity = 56000.0
                        },
                        new
                        {
                            Id = 4,
                            LeagueId = 2,
                            ManagerName = "Zinedine Zidane",
                            Name = "Real Madrid",
                            StadiumName = "Santiago Bernabeau",
                            stadiumCapacity = 81040.0
                        },
                        new
                        {
                            Id = 5,
                            LeagueId = 2,
                            ManagerName = "Ronald Koeman",
                            Name = "Barcelona",
                            StadiumName = "Camp Nou",
                            stadiumCapacity = 99500.0
                        },
                        new
                        {
                            Id = 6,
                            LeagueId = 3,
                            ManagerName = "Stefano Pioli",
                            Name = "AC Milan",
                            StadiumName = "San Siro",
                            stadiumCapacity = 81500.0
                        },
                        new
                        {
                            Id = 7,
                            LeagueId = 3,
                            ManagerName = "Andrea Pirlo",
                            Name = "Juventus",
                            StadiumName = "Allianz Stadium",
                            stadiumCapacity = 42000.0
                        },
                        new
                        {
                            Id = 8,
                            LeagueId = 4,
                            ManagerName = "Lucien Favre",
                            Name = "Borussia Dortmund",
                            StadiumName = "Signal Iduna Park",
                            stadiumCapacity = 81000.0
                        },
                        new
                        {
                            Id = 9,
                            LeagueId = 5,
                            ManagerName = "Neil Lennon",
                            Name = "Celtic FC",
                            StadiumName = "Celtic Park",
                            stadiumCapacity = 61000.0
                        },
                        new
                        {
                            Id = 10,
                            LeagueId = 6,
                            ManagerName = "Filipe Celikkaya",
                            Name = "Sporting Lisbon",
                            StadiumName = "Academia Sporting",
                            stadiumCapacity = 50000.0
                        });
                });

            modelBuilder.Entity("EuropeLeagues.API.Entities.League", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("DateofCreation")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Group")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Leagues");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Country = "England",
                            DateofCreation = new DateTimeOffset(new DateTime(1992, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            Group = "A",
                            Name = "English Premier League"
                        },
                        new
                        {
                            Id = 2,
                            Country = "Spain",
                            DateofCreation = new DateTimeOffset(new DateTime(1980, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            Group = "A",
                            Name = "Spanish La Liga"
                        },
                        new
                        {
                            Id = 3,
                            Country = "Italy",
                            DateofCreation = new DateTimeOffset(new DateTime(1978, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            Group = "A",
                            Name = "Italian Serie A"
                        },
                        new
                        {
                            Id = 4,
                            Country = "Germany",
                            DateofCreation = new DateTimeOffset(new DateTime(1980, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            Group = "B",
                            Name = "German Bundesliga"
                        },
                        new
                        {
                            Id = 5,
                            Country = "Scotland",
                            DateofCreation = new DateTimeOffset(new DateTime(1988, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            Group = "B",
                            Name = "Scottish Premier League"
                        },
                        new
                        {
                            Id = 6,
                            Country = "Portugal",
                            DateofCreation = new DateTimeOffset(new DateTime(1995, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            Group = "C",
                            Name = "Primeira Liga"
                        });
                });

            modelBuilder.Entity("EuropeLeagues.API.Entities.FootballClub", b =>
                {
                    b.HasOne("EuropeLeagues.API.Entities.League", "League")
                        .WithMany("Clubs")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("League");
                });

            modelBuilder.Entity("EuropeLeagues.API.Entities.League", b =>
                {
                    b.Navigation("Clubs");
                });
#pragma warning restore 612, 618
        }
    }
}
