using CRM_Dashboard.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Dashboard.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<ProjectsType> ProjectsTypes { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }
        public DbSet<CompaniesType> CompaniesTypes { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<VisitService> VisitServices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<DealStage> DealStages { get; set; }
        public DbSet<DealPayment> DealPayments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<File> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectsType>()
                .HasKey(pt => pt.Id);

            modelBuilder.Entity<ProjectsType>()
                .HasOne(pt => pt.Project)
                .WithMany(p => p.ProjectsTypes)
                .HasForeignKey(pt => pt.ProjectId);

            modelBuilder.Entity<ProjectsType>()
                .HasOne(pt => pt.ProjectType)
                .WithMany(projectType => projectType.ProjectsTypes)
                .HasForeignKey(pt => pt.ProjectTypeId);

            modelBuilder.Entity<CompaniesType>()
                .HasKey(pt => pt.Id);

            modelBuilder.Entity<CompaniesType>()
                .HasOne(ct => ct.Company)
                .WithMany(c => c.CompaniesTypes)
                .HasForeignKey(ct => ct.CompanyId);

            modelBuilder.Entity<CompaniesType>()
                .HasOne(ct => ct.CompanyType)
                .WithMany(companyType => companyType.CompaniesTypes)
                .HasForeignKey(ct => ct.CompanyTypeId);

            modelBuilder.Entity<VisitService>()
                .HasOne(vs => vs.Visit)
                .WithMany(v => v.VisitServices)
                .HasForeignKey(vs => vs.VisitId);

            modelBuilder.Entity<VisitService>()
                .HasOne(vs => vs.Service)
                .WithMany(s => s.VisitServices)
                .HasForeignKey(vs => vs.ServiceId);

            modelBuilder.Entity<Visit>()
                .Property(v => v.VisitRating)
                .HasConversion<int>();

            modelBuilder.Entity<Deal>()
                .Property(d => d.TypePayment)
                .HasConversion<int>();

            modelBuilder.Entity<Deal>()
                .Property(d => d.Currency)
                .HasConversion<int>();

            modelBuilder.Entity<DealStage>()
                .Property(ds => ds.DealStageName)
                .HasConversion<int>();

            modelBuilder.Entity<DealPayment>()
                .Property(dp => dp.Currency)
                .HasConversion<int>();
            

            base.OnModelCreating(modelBuilder);
        }

    }
}
