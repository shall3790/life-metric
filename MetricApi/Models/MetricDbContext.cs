using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MetricApi.Models
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

        public virtual DbSet<MetricGroup> MetricGroup { get; set; }
        public virtual DbSet<MetricName> MetricName { get; set; }

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
            modelBuilder.Entity<MetricGroup>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<MetricName>(entity =>
            {
                entity.Property(e => e.GroupId).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.MetricName)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MetricGroupId");
            });
        }
    }
}
