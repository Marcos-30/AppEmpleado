using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AplicacionEmpleado.Models;

public partial class DbempleadosContext : DbContext
{
    public DbempleadosContext()
    {
    }

    public DbempleadosContext(DbContextOptions<DbempleadosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; } = null;

    public virtual DbSet<Empleado> Empleados { get; set; } = null;

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.IdCargo).HasName("PK__CARGO__6C985625B348A129");

            entity.ToTable("CARGO");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__EMPLEADO__CE6D8B9E3998C6F6");

            entity.ToTable("EMPLEADO");

            entity.Property(e => e.Correo)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(60)
                .IsUnicode(false);

            entity.HasOne(d => d.oCargo).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdCargo)
                .HasConstraintName("FK__EMPLEADO__IdCarg__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
