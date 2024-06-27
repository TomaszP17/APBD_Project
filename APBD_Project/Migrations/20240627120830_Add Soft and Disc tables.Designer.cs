﻿// <auto-generated />
using System;
using APBD_Project.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APBD_Project.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20240627120830_Add Soft and Disc tables")]
    partial class AddSoftandDisctables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.5.24306.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APBD_Project.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ClientId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Address");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)")
                        .HasColumnName("PhoneNumber");

                    b.HasKey("ClientId");

                    b.ToTable("Clients", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("APBD_Project.Models.Discount", b =>
                {
                    b.Property<int>("DiscountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DiscountId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiscountId"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("EndDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.Property<double>("Percentage")
                        .HasColumnType("float")
                        .HasColumnName("Percentage");

                    b.Property<int>("SoftwareId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("StartDate");

                    b.HasKey("DiscountId");

                    b.HasIndex("SoftwareId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("APBD_Project.Models.Software", b =>
                {
                    b.Property<int>("SoftwareId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SoftwareId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SoftwareId"));

                    b.Property<string>("ActualVersion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ActualVersion");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Category");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.Property<double>("Price")
                        .HasColumnType("float")
                        .HasColumnName("Price");

                    b.HasKey("SoftwareId");

                    b.ToTable("Softwares");
                });

            modelBuilder.Entity("APBD_Project.Models.CompanyClient", b =>
                {
                    b.HasBaseType("APBD_Project.Models.Client");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CompanyName");

                    b.Property<string>("KRSNumber")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)")
                        .HasColumnName("KRSNumber");

                    b.ToTable("CompanyClients", (string)null);

                    b.HasData(
                        new
                        {
                            ClientId = 4,
                            Address = "456 Corporate Blvd",
                            Email = "contact@abccorp.com",
                            PhoneNumber = "066655999",
                            CompanyName = "ABC Corp",
                            KRSNumber = "9876543210"
                        },
                        new
                        {
                            ClientId = 5,
                            Address = "789 Business Rd",
                            Email = "info@xyzltd.com",
                            PhoneNumber = "333222111",
                            CompanyName = "XYZ Ltd",
                            KRSNumber = "8765432109"
                        },
                        new
                        {
                            ClientId = 6,
                            Address = "123 Enterprise Ave",
                            Email = "support@mnoinc.com",
                            PhoneNumber = "888999777",
                            CompanyName = "MNO Inc",
                            KRSNumber = "7654321098"
                        });
                });

            modelBuilder.Entity("APBD_Project.Models.IndividualClient", b =>
                {
                    b.HasBaseType("APBD_Project.Models.Client");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("FirstName");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("IsDeleted");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("LastName");

                    b.Property<string>("Pesel")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("Pesel");

                    b.ToTable("IndividualClients", (string)null);

                    b.HasData(
                        new
                        {
                            ClientId = 1,
                            Address = "123 Main St",
                            Email = "john.doe@example.com",
                            PhoneNumber = "123456789",
                            FirstName = "John",
                            IsDeleted = false,
                            LastName = "Doe",
                            Pesel = "12345678901"
                        },
                        new
                        {
                            ClientId = 2,
                            Address = "456 Elm St",
                            Email = "jane.smith@example.com",
                            PhoneNumber = "213456789",
                            FirstName = "Jane",
                            IsDeleted = false,
                            LastName = "Smith",
                            Pesel = "23456789012"
                        },
                        new
                        {
                            ClientId = 3,
                            Address = "789 Oak St",
                            Email = "alice.johnson@example.com",
                            PhoneNumber = "987654321",
                            FirstName = "Alice",
                            IsDeleted = false,
                            LastName = "Johnson",
                            Pesel = "34567890123"
                        });
                });

            modelBuilder.Entity("APBD_Project.Models.Discount", b =>
                {
                    b.HasOne("APBD_Project.Models.Software", "Software")
                        .WithMany("Discounts")
                        .HasForeignKey("SoftwareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Software");
                });

            modelBuilder.Entity("APBD_Project.Models.CompanyClient", b =>
                {
                    b.HasOne("APBD_Project.Models.Client", null)
                        .WithOne()
                        .HasForeignKey("APBD_Project.Models.CompanyClient", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("APBD_Project.Models.IndividualClient", b =>
                {
                    b.HasOne("APBD_Project.Models.Client", null)
                        .WithOne()
                        .HasForeignKey("APBD_Project.Models.IndividualClient", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("APBD_Project.Models.Software", b =>
                {
                    b.Navigation("Discounts");
                });
#pragma warning restore 612, 618
        }
    }
}