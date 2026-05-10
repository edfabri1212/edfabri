using System;
using System.Collections.Generic;
using EFAA.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFAA.DataAccess;

public partial class QuotationContext : DbContext
{
    public QuotationContext()
    {
    }

    public QuotationContext(DbContextOptions<QuotationContext> options)
        : base(options)
    {
    }

    // DbSet actualizados a Designers y Garments
    public virtual DbSet<Designer> Designers { get; set; }

    public virtual DbSet<Garment> Garments { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Designer>(entity =>
        {
            // Ajuste de PK para Designers
            entity.HasKey(e => e.Id).HasName("PK__Designer__3214EC07F74D8D72");

            entity.Property(e => e.FullName)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Garment>(entity =>
        {
            // Ajuste de PK para Garments
            entity.HasKey(e => e.Id).HasName("PK__Garments__3214EC0727792809");

            entity.Property(e => e.MarketPrice).HasColumnType("decimal(18, 2)");

            // Se mantiene ProductName o se cambia a GarmentName según tus entidades
            entity.Property(e => e.ProductName)
                .HasMaxLength(200)
                .IsUnicode(false);

            // Relación actualizada: Una prenda tiene un Diseñador, un Diseñador tiene muchas Prendas
            entity.HasOne(d => d.Designer).WithMany(p => p.Garments)
                .HasForeignKey(d => d.DesignerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Garments__Design__5165187F");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC0746834AA0");

            entity.Property(e => e.PositionName)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07D1AFE088");

            entity.Property(e => e.Handle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SecretHash).IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__RoleId__4CA06362");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
