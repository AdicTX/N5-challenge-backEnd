using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace N5challenge.Models;

public partial class N5challengeContext : DbContext
{
    public N5challengeContext()
    {
    }

    public N5challengeContext(DbContextOptions<N5challengeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<PermissionType> PermissionTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__permissi__3213E83F70DC14C5");

            entity.ToTable("permission");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidoempleado)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("apellidoempleado");
            entity.Property(e => e.Fechapermiso).HasColumnName("fechapermiso");
            entity.Property(e => e.Nombreempleado)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombreempleado");
            entity.Property(e => e.Tipopermiso).HasColumnName("tipopermiso");

            entity.HasOne(d => d.TipopermisoNavigation).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.Tipopermiso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__permissio__tipop__4BAC3F29");
        });

        modelBuilder.Entity<PermissionType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__permissi__3213E83FC618652D");

            entity.ToTable("permissionType");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
