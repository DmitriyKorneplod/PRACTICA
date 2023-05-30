using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PR_TransportCompany.Models;

public partial class TransportCompanyContext : DbContext
{
    public TransportCompanyContext()
    {
    }

    public TransportCompanyContext(DbContextOptions<TransportCompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.0.1\\SQLEXPRESS;User=is51_0;Password=12345678Aa;Database=transport_company;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_PK");

            entity.ToTable("product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("manufacturer");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Route>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("route_PK");

            entity.ToTable("route");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PointOfDeparture)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("point_of_departure");
            entity.Property(e => e.PointOfStay)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("point_of_stay");
            entity.Property(e => e.Product)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("product");
            entity.Property(e => e.Transport)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("transport");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_PK");

            entity.ToTable("user");

            entity.HasIndex(e => e.Login, "user_UN").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fio)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("fio");
            entity.Property(e => e.Login)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
