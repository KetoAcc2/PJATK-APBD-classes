using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test1.Models
{
    public class S21120_DbContext : DbContext
    {
        public S21120_DbContext()
        {

        }

        public S21120_DbContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Plane> Planes { get; set; }
        public virtual DbSet<CityDict> CityDicts { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<FlightPassenger> FlightPassengers { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s21120;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Planes
            var plane1 = new Plane
            {
                IdPlane = 1,
                Name = "planeName1",
                MaxSeats = 50
            };

            // Planes
            var plane2 = new Plane
            {
                IdPlane = 2,
                Name = "planeName2",
                MaxSeats = 30
            };

            // Planes
            var plane3 = new Plane
            {
                IdPlane = 3,
                Name = "planeName3",
                MaxSeats = 60
            };

            modelBuilder.Entity<Plane>(entity =>
            {
                entity.ToTable(nameof(Plane));

                entity.HasKey(e => e.IdPlane);
                entity.Property(e => e.IdPlane).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).IsRequired()
                                         .HasMaxLength(50);


                entity.Property(e => e.MaxSeats).IsRequired();

                entity.HasData(plane1, plane2, plane3);
            });

            // Planes
            var cityDict1 = new CityDict
            {
                IdCityDict = 1,
                City = "cityName1"
            };

            // Planes
            var cityDict2 = new CityDict
            {
                IdCityDict = 2,
                City = "cityName2"
            };

            // Planes
            var cityDict3 = new CityDict
            {
                IdCityDict = 3,
                City = "cityName3"
            };

            modelBuilder.Entity<CityDict>(entity =>
            {
                entity.ToTable(nameof(CityDict));

                entity.HasKey(e => e.IdCityDict);
                entity.Property(e => e.IdCityDict).ValueGeneratedOnAdd();

                entity.Property(e => e.City).IsRequired()
                                         .HasMaxLength(30);

                entity.HasData(cityDict1, cityDict2, cityDict3);
            });

            // Passenger
            var passenger1 = new Passenger
            {
                IdPassenger = 1,
                FirstName = "firstName1",
                LastName = "lastName1",
                PassportNum = "11111111111",
            };

            // 
            var passenger2 = new Passenger
            {
                IdPassenger = 2,
                FirstName = "firstName2",
                LastName = "lastName2",
                PassportNum = "2222222222222",
            };

            // 
            var passenger3 = new Passenger
            {
                IdPassenger = 3,
                FirstName = "firstName3",
                LastName = "lastName3",
                PassportNum = "3333333333",
            };

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.ToTable(nameof(Passenger));

                entity.HasKey(e => e.IdPassenger);
                entity.Property(e => e.IdPassenger).ValueGeneratedOnAdd();

                entity.Property(e => e.FirstName).IsRequired()
                                         .HasMaxLength(50);

                entity.Property(e => e.LastName).IsRequired()
                                         .HasMaxLength(60);

                entity.Property(e => e.PassportNum).IsRequired()
                                         .HasMaxLength(20);

                entity.HasData(passenger1, passenger2, passenger3);
            });

            // Flight
            var flight1 = new Flight
            {
                IdFlight = 1,
                FlightDate = DateTime.Now,
                Comments = "comments1",
                IdPlane = 1,
                IdCityDict = 1
            };

            var flight2 = new Flight
            {
                IdFlight = 2,
                FlightDate = DateTime.Now.AddDays(10),
                Comments = "comments2",
                IdPlane = 2,
                IdCityDict = 2
            };

            var flight3 = new Flight
            {
                IdFlight = 3,
                FlightDate = DateTime.Now.AddDays(20),
                Comments = "comments3",
                IdPlane = 3,
                IdCityDict = 3
            };

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable(nameof(Flight));

                entity.HasKey(e => e.IdFlight);
                entity.Property(e => e.IdFlight).ValueGeneratedOnAdd();

                entity.Property(e => e.FlightDate).HasColumnType("datetime");

                entity.Property(e => e.Comments).IsRequired()
                                         .HasMaxLength(200);

                entity.HasOne(e => e.IdPlaneNavigation)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(e => e.IdPlane);

                entity.HasOne(e => e.IdCityDictNavigation)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(e => e.IdCityDict);

                entity.HasData(flight1, flight2, flight3);
            });

            // Flight
            var flightPassenger1 = new FlightPassenger
            {
                IdFlight = 1,
                IdPassenger = 1
            };

            // Flight
            var flightPassenger2 = new FlightPassenger
            {
                IdFlight = 2,
                IdPassenger = 2
            };

            // Flight
            var flightPassenger3 = new FlightPassenger
            {
                IdFlight = 3,
                IdPassenger = 3
            };

            modelBuilder.Entity<FlightPassenger>(entity =>
            {
                entity.ToTable(nameof(FlightPassenger));

                entity.HasKey(e => new { e.IdFlight, e.IdPassenger })
                    .HasName("Flight_Passenger_PK");


                entity.HasOne(e => e.IdFlightNavigation)
                    .WithMany(p => p.FlightPassengers)
                    .HasForeignKey(e => e.IdFlight);

                entity.HasOne(e => e.IdPassengerNavigation)
                    .WithMany(p => p.FlightPassengers)
                    .HasForeignKey(e => e.IdPassenger);

                entity.HasData(flightPassenger1, flightPassenger2, flightPassenger3);

            });

        }

    }
}
