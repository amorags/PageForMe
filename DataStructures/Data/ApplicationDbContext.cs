using Microsoft.EntityFrameworkCore;
using PageForMe.Models;

namespace PageForMe.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Employee configuration
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.HireDate)
                    .HasColumnType("timestamp with time zone");
            });

            // Project configuration
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasOne(p => p.Employee)
                      .WithMany(e => e.Projects)
                      .HasForeignKey(p => p.EmployeeId)
                      .OnDelete(DeleteBehavior.Cascade);
                
                entity.Property(p => p.CreatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(p => p.UpdatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(p => p.StartDate)
                    .HasColumnType("timestamp with time zone");
                entity.Property(p => p.EndDate)
                    .HasColumnType("timestamp with time zone");
            });

            // Sale configuration
            modelBuilder.Entity<Sale>(entity =>
            {
                entity.Property(s => s.CreatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(s => s.SaleDate)
                    .HasColumnType("timestamp with time zone");
                entity.HasIndex(s => s.SaleDate);
                entity.HasIndex(s => s.Region);
                entity.HasIndex(s => s.Category);
            });
        }
    }
}