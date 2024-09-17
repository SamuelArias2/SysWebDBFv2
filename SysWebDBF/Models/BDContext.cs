using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SysWebDBF.Models;

public partial class BDContext : DbContext
{
    public BDContext()
    {
    }

    public BDContext(DbContextOptions<BDContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Accesorio> Accesorio { get; set; }

    public virtual DbSet<CarritoCompra> CarritoCompra { get; set; }

    public virtual DbSet<CarritoProducto> CarritoProducto { get; set; }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<Factura> Factura { get; set; }

    public virtual DbSet<Producto> Producto { get; set; }

    public virtual DbSet<Ropa> Ropa { get; set; }

    public virtual DbSet<Venta> Venta { get; set; }

    public virtual DbSet<VentaProducto> VentaProducto { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDboutique;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accesorio>(entity =>
        {
            entity.HasKey(e => e.IdAccesorio).HasName("PK__Accesori__F5A743CC4B88F691");

            entity.Property(e => e.IdAccesorio).ValueGeneratedNever();

            entity.HasOne(d => d.IdAccesorioNavigation).WithOne(p => p.Accesorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Accesorio__idAcc__3B75D760");
        });

        modelBuilder.Entity<CarritoCompra>(entity =>
        {
            entity.HasKey(e => e.IdCarrito).HasName("PK__CarritoC__7AF85448C7FC3E69");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.CarritoCompra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CarritoCo__idCli__46E78A0C");
        });

        modelBuilder.Entity<CarritoProducto>(entity =>
        {
            entity.HasKey(e => new { e.IdCarrito, e.IdProducto }).HasName("PK__CarritoP__4A871E5BB18DE6B0");

            entity.HasOne(d => d.IdCarritoNavigation).WithMany(p => p.CarritoProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CarritoPr__idCar__49C3F6B7");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.CarritoProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CarritoPr__idPro__4AB81AF0");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__885457EE1E0EB2C0");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("PK__Factura__3CD5687E494D0A6F");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.Factura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Factura__idVenta__440B1D61");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__07F4A132F59BD1F7");
        });

        modelBuilder.Entity<Ropa>(entity =>
        {
            entity.HasKey(e => e.IdRopa).HasName("PK__Ropa__E5072A89EBC190EF");

            entity.Property(e => e.IdRopa).ValueGeneratedNever();

            entity.HasOne(d => d.IdRopaNavigation).WithOne(p => p.Ropa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ropa__idRopa__3E52440B");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__Venta__077D56143268DD5A");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Venta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Venta__idCliente__412EB0B6");
        });

        modelBuilder.Entity<VentaProducto>(entity =>
        {
            entity.HasKey(e => new { e.IdVenta, e.IdProducto }).HasName("PK__VentaPro__37021C07FCEC8FC3");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.VentaProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VentaProd__idPro__4E88ABD4");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.VentaProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VentaProd__idVen__4D94879B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
