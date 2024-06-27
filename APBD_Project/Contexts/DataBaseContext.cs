using APBD_Project.Models;
using Microsoft.EntityFrameworkCore;
using Contract = System.Diagnostics.Contracts.Contract;

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
                FirstName = "John",
                LastName = "Doe",
                Pesel = "12345678901",
                Address = "123 Main St",
                Email = "john.doe@example.com",
                PhoneNumber = "123456789",
                IsDeleted = false
            },
            new IndividualClient
            {
                ClientId = 2,
                FirstName = "Jane",
                LastName = "Smith",
                Pesel = "23456789012",
                Address = "456 Elm St",
                Email = "jane.smith@example.com",
                PhoneNumber = "213456789",
                IsDeleted = false
            },
            new IndividualClient
            {
                ClientId = 3,
                FirstName = "Alice",
                LastName = "Johnson",
                Pesel = "34567890123",
                Address = "789 Oak St",
                Email = "alice.johnson@example.com",
                PhoneNumber = "987654321",
                IsDeleted = false
            }
        );

        
        modelBuilder.Entity<CompanyClient>().HasData(
            new CompanyClient
            {
                ClientId = 4,
                CompanyName = "ABC Corp",
                KRSNumber = "9876543210",
                Address = "456 Corporate Blvd",
                Email = "contact@abccorp.com",
                PhoneNumber = "066655999"
            },
            new CompanyClient
            {
                ClientId = 5,
                CompanyName = "XYZ Ltd",
                KRSNumber = "8765432109",
                Address = "789 Business Rd",
                Email = "info@xyzltd.com",
                PhoneNumber = "333222111"
            },
            new CompanyClient
            {
                ClientId = 6,
                CompanyName = "MNO Inc",
                KRSNumber = "7654321098",
                Address = "123 Enterprise Ave",
                Email = "support@mnoinc.com",
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