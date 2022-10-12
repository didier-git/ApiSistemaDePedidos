using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PruebaTSistemaDePedidos.Models;

namespace PruebaTSistemaDePedidos.Context
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TdetallesPorPedido> TdetallesPorPedidos { get; set; } = null!;
        public virtual DbSet<Tpedido> Tpedidos { get; set; } = null!;
        public virtual DbSet<Tproducto> Tproductos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=didier\\sqlexpress;Database=PruebaTU;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TdetallesPorPedido>(entity =>
            {
                entity.HasKey(e => e.IdDetalle);

                entity.ToTable("TDetallesPorPedido");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.TdetallesPorPedidos)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdPedido");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.TdetallesPorPedidos)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdProducto");
            });

            modelBuilder.Entity<Tpedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido);

                entity.ToTable("TPedidos");

                entity.Property(e => e.IdPedido).ValueGeneratedNever();

                entity.Property(e => e.Direccion).HasMaxLength(50);

                entity.Property(e => e.IdentificacionCliente)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCliente).HasMaxLength(50);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tproducto>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.ToTable("TProducto");

                entity.Property(e => e.Nombre).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
