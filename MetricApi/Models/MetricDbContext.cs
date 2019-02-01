using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace metric-api.Models
{
    public partial class MetricDbContext : DbContext
    {
        public MetricDbContext()
        {
        }

        public MetricDbContext(DbContextOptions<MetricDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Metricgroup> Metricgroup { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=metricdb;Username=admin;Password=password");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Metricgroup>(entity =>
            {
                entity.ToTable("metricgroup");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(256);
            });
        }
    }
}
