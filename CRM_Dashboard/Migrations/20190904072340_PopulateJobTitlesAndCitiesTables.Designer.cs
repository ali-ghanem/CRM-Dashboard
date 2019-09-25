﻿// <auto-generated />
using System;
using CRM_Dashboard.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CRM_Dashboard.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190904072340_PopulateJobTitlesAndCitiesTables")]
    partial class PopulateJobTitlesAndCitiesTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CRM_Dashboard.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("CRM_Dashboard.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("CRM_Dashboard.Models.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int>("CityId");

                    b.Property<int?>("CountryId");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<int>("GenderId");

                    b.Property<long>("JobTitleId");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<int?>("Nationality1Id");

                    b.Property<int?>("Nationality2Id");

                    b.Property<string>("Notes");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("GenderId");

                    b.HasIndex("JobTitleId");

                    b.HasIndex("Nationality1Id");

                    b.HasIndex("Nationality2Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CRM_Dashboard.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Genders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Male"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Female"
                        });
                });

            modelBuilder.Entity("CRM_Dashboard.Models.JobTitle", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("JobTitles");
                });

            modelBuilder.Entity("CRM_Dashboard.Models.Nationality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Nationalities");
                });

            modelBuilder.Entity("CRM_Dashboard.Models.Customer", b =>
                {
                    b.HasOne("CRM_Dashboard.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CRM_Dashboard.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("CRM_Dashboard.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CRM_Dashboard.Models.JobTitle", "JobTitle")
                        .WithMany()
                        .HasForeignKey("JobTitleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CRM_Dashboard.Models.Nationality", "Nationality1")
                        .WithMany()
                        .HasForeignKey("Nationality1Id");

                    b.HasOne("CRM_Dashboard.Models.Nationality", "Nationality2")
                        .WithMany()
                        .HasForeignKey("Nationality2Id");
                });
#pragma warning restore 612, 618
        }
    }
}
