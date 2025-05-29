using ISExam.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISExam.Data
{
    public class MainContext : DbContext
    {
        private readonly IConfiguration configuration;

        public MainContext(DbContextOptions<MainContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            if (optionsBuilder.IsConfigured)
                return;

            optionsBuilder.UseSqlServer(configuration.GetSection("DefaultConnection").Value,
                x => x.MigrationsAssembly("ISExam.Data"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Client>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Movie>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Movie>()
                .Property(m => m.Name).IsRequired();

            modelBuilder.Entity<Movie>()
                .Property(m => m.Director).IsRequired();

            modelBuilder.Entity<Movie>()
                .Property(m => m.Year).IsRequired();

            modelBuilder.Entity<Movie>()
                .Property(m => m.Rating).IsRequired();

            modelBuilder.Entity<Movie>()
                .Property(m => m.BoxOfficeEarnings).IsRequired();

            modelBuilder.Entity<Client>()
                .Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Client>()
                .Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Client>()
                .Property(c => c.Address)
                .IsRequired()
                .HasMaxLength(300);

            modelBuilder.Entity<Client>()
                .Property(c => c.MembershipCardNumber)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(c => c.MembershipValidityDate)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(c => c.RentDate)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(c => c.ReturnDate)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(c => c.DOB)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .HasOne(c => c.Movie)
                .WithMany(m => m.Clients)
                .HasForeignKey(c => c.MovieId);

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Clients)
                .WithOne(c => c.Movie)
                .HasForeignKey(c => c.MovieId);

            modelBuilder.Entity<Movie>()
                .HasData(
                    new Movie
                    {
                        Id = 1,
                        Name = "Movie 1",
                        Director = "Director for Movie 1",
                        BoxOfficeEarnings = 15000.00f,
                        Genre = "Comedy",
                        Rating = 4.5f,
                        Year = 2025
                    },
                    new Movie
                    {
                        Id = 2,
                        Name = "Movie 2",
                        Director = "Director for Movie 2",
                        BoxOfficeEarnings = 500.00f,
                        Genre = "Drama",
                        Rating = 1.5f,
                        Year = 2015
                    }
                );

            modelBuilder.Entity<Client>()
                .HasData(
                    new Client
                    {
                        Id = 1,
                        Address = "Street 1, Number 20B",
                        DOB = new DateTime(2002, 2, 4),
                        FirstName = "Imen",
                        LastName = "Prezimovski",
                        MembershipCardNumber = 1234,
                        MembershipValidityDate = new DateTime(2025, 4, 3),
                        MovieId = 1,
                        RentDate = new DateTime(2025, 4, 3).AddDays(-5),
                        ReturnDate = new DateTime(2025, 4, 3).AddDays(2)
                    },
                    new Client
                    {
                        Id = 2,
                        Address = "Street 5, Number 63A",
                        DOB = new DateTime(2025, 4, 3).AddYears(-34),
                        FirstName = "Test",
                        LastName = "Testovski",
                        MembershipCardNumber = 4567,
                        MembershipValidityDate = new DateTime(2025, 4, 3).AddDays(16),
                        MovieId = 2,
                        RentDate = new DateTime(2025, 4, 3),
                        ReturnDate = new DateTime(2025, 4, 3).AddDays(7)
                    }
                );

        }
    }
}
