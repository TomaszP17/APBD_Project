using APBD_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_Project.Contexts;

public class DataBaseContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<IndividualClient> IndividualClients { get; set; }
    public DbSet<CompanyClient> CompanyClients { get; set; }
    public DbSet<Software> Softwares { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Models.Contract> Contracts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    
    protected DataBaseContext()
    {
    }

    public DataBaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Client>()
            .ToTable("Clients");

        modelBuilder.Entity<IndividualClient>()
            .ToTable("IndividualClients");

        modelBuilder.Entity<CompanyClient>()
            .ToTable("CompanyClients");
        
        
        modelBuilder.Entity<IndividualClient>().HasData(
            new IndividualClient
            {
                ClientId = 1,
                FirstName = "Mariusz",
                LastName = "Pudzianowski",
                Pesel = "12345678901",
                Address = "palac 2",
                Email = "mariuszp@example.com",
                PhoneNumber = "123456789",
                IsDeleted = false
            },
            new IndividualClient
            {
                ClientId = 2,
                FirstName = "Major",
                LastName = "Suchodolski",
                Pesel = "23456789012",
                Address = "Szkolna",
                Email = "major.sucho@example.com",
                PhoneNumber = "213456789",
                IsDeleted = false
            },
            new IndividualClient
            {
                ClientId = 3,
                FirstName = "Alicja",
                LastName = "Zczarow",
                Pesel = "34567890123",
                Address = "kraina czaorw",
                Email = "alicja.zczarow@example.com",
                PhoneNumber = "987654321",
                IsDeleted = false
            }
        );

        
        modelBuilder.Entity<CompanyClient>().HasData(
            new CompanyClient
            {
                ClientId = 4,
                CompanyName = "drutex",
                KRSNumber = "9876543210",
                Address = "podkarpacie 30",
                Email = "kontakt@drutex.com",
                PhoneNumber = "066655999"
            },
            new CompanyClient
            {
                ClientId = 5,
                CompanyName = "miau miau sa",
                KRSNumber = "8765432109",
                Address = "kocia 69",
                Email = "info@kocie.com",
                PhoneNumber = "333222111"
            },
            new CompanyClient
            {
                ClientId = 6,
                CompanyName = "halny wiatr",
                KRSNumber = "7654321098",
                Address = "zakopane 15",
                Email = "support@zakopane.com",
                PhoneNumber = "888999777"
            }
        );
        
        modelBuilder.Entity<Payment>()
            .HasOne(p => p.Client)
            .WithMany(c => c.Payments)
            .HasForeignKey(p => p.ClientId)
            .OnDelete(DeleteBehavior.NoAction);
        
    }
}