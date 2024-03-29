﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using N5challenge.Models;

#nullable disable

namespace N5challenge.Migrations
{
    [DbContext(typeof(N5challengeContext))]
    partial class N5challengeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("N5challenge.Models.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidoempleado")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("apellidoempleado");

                    b.Property<DateOnly>("Fechapermiso")
                        .HasColumnType("date")
                        .HasColumnName("fechapermiso");

                    b.Property<string>("Nombreempleado")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nombreempleado");

                    b.Property<int>("Tipopermiso")
                        .HasColumnType("int")
                        .HasColumnName("tipopermiso");

                    b.HasKey("Id")
                        .HasName("PK__permissi__3213E83F70DC14C5");

                    b.HasIndex("Tipopermiso");

                    b.ToTable("permission", (string)null);
                });

            modelBuilder.Entity("N5challenge.Models.PermissionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("descripcion");

                    b.HasKey("Id")
                        .HasName("PK__permissi__3213E83FC618652D");

                    b.ToTable("permissionType", (string)null);
                });

            modelBuilder.Entity("N5challenge.Models.Permission", b =>
                {
                    b.HasOne("N5challenge.Models.PermissionType", "TipopermisoNavigation")
                        .WithMany("Permissions")
                        .HasForeignKey("Tipopermiso")
                        .IsRequired()
                        .HasConstraintName("FK__permissio__tipop__4BAC3F29");

                    b.Navigation("TipopermisoNavigation");
                });

            modelBuilder.Entity("N5challenge.Models.PermissionType", b =>
                {
                    b.Navigation("Permissions");
                });
#pragma warning restore 612, 618
        }
    }
}
