using EuropeLeagues.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuropeLeagues.API.DbContexts
{
    public class EuropeLeagueContext : DbContext
    {
        public EuropeLeagueContext(DbContextOptions<EuropeLeagueContext> options) : base(options)
        {

        }

        public DbSet<League> Leagues { get; set; }

        public DbSet<FootballClub> Clubs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<League>().HasData(
                new League()
                {
                    Id = 1,
                    Name = "English Premier League",
                    DateofCreation = new DateTime(1992, 8, 1),
                    Country = "England",
                    Group = "A"
                },
                new League()
                {
                    Id = 2,
                    Name = "Spanish La Liga",
                    DateofCreation = new DateTime(1980, 3, 1),
                    Country = "Spain",
                    Group = "A"
                },
                new League()
                {
                    Id = 3,
                    Name = "Italian Serie A",
                    DateofCreation = new DateTime(1978, 6, 15),
                    Country = "Italy",
                    Group = "A"
                },
                new League()
                {
                    Id = 4,
                    Name = "German Bundesliga",
                    DateofCreation = new DateTime(1980, 7, 12),
                    Country = "Germany",
                    Group = "B"
                },
                new League()
                {
                    Id = 5,
                    Name = "Scottish Premier League",
                    DateofCreation = new DateTime(1988, 1, 19),
                    Country = "Scotland",
                    Group = "B"
                },
                new League()
                {
                    Id = 6,
                    Name = "Primeira Liga",
                    DateofCreation = new DateTime(1995, 4, 15),
                    Country = "Portugal",
                    Group = "C"
                }
                );
            // ................ Football Clubs ..........................//
            modelBuilder.Entity<FootballClub>().HasData(
               new FootballClub
                {
                   Id = 1,
                   Name = "Manchester United",
                   ManagerName = "Ole Gunnar Solskjaer",
                   StadiumName = "Old Trafford",
                   LeagueId = 1,
                   stadiumCapacity = 75000
                },
               new FootballClub
                {
                   Id = 2,
                   Name = "Chelsea FC",
                   ManagerName = "Frank Lampard",
                   StadiumName = "Stamford Bridge",
                   LeagueId = 1,
                   stadiumCapacity = 40500
               },
               new FootballClub
                {
                  Id = 3,
                  Name = "Manchester City",
                  ManagerName = "Pep Guardiola",
                  StadiumName = "City of Manchester Stadium",
                  LeagueId = 1,
                   stadiumCapacity = 56000
               },
               new FootballClub
                {
                   Id = 4,
                   Name = "Real Madrid",
                   ManagerName = "Zinedine Zidane",
                   StadiumName = "Santiago Bernabeau",
                   LeagueId = 2,
                   stadiumCapacity = 81040
               },
               new FootballClub
               {
                   Id = 5,
                   Name = "Barcelona",
                   ManagerName = "Ronald Koeman",
                   StadiumName = "Camp Nou",
                   LeagueId = 2,
                   stadiumCapacity = 99500
               },
               new FootballClub
                {
                    Id = 6,
                    Name = "AC Milan",
                    ManagerName = "Stefano Pioli",
                    StadiumName = "San Siro",
                    LeagueId = 3,
                   stadiumCapacity = 81500
               },
                new FootballClub
                {
                    Id = 7,
                    Name = "Juventus",
                    ManagerName = "Andrea Pirlo",
                    StadiumName = "Allianz Stadium",
                    LeagueId = 3,
                    stadiumCapacity = 42000
                },
                 new FootballClub
                 {
                     Id = 8,
                     Name = "Borussia Dortmund",
                     ManagerName = "Lucien Favre",
                     StadiumName = "Signal Iduna Park",
                     LeagueId = 4,
                     stadiumCapacity = 81000
                 },
                 new FootballClub
                 {
                      Id = 9,
                      Name = "Celtic FC",
                      ManagerName = "Neil Lennon",
                      StadiumName = "Celtic Park",
                      LeagueId = 5,
                     stadiumCapacity = 61000
                 },
                  new FootballClub
                  {
                       Id = 10,
                       Name = "Sporting Lisbon",
                       ManagerName = "Filipe Celikkaya",
                       StadiumName = "Academia Sporting",
                       LeagueId = 6,
                      stadiumCapacity = 50000
                  }
               );

            base.OnModelCreating(modelBuilder);
        }
    }
}
