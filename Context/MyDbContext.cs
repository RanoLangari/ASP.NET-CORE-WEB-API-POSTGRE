using System;
using System.Collections.Generic;
using CRUD_ASP.POSTGRESQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD_ASP.POSTGRESQL.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblBarang> TblBarangs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=db-barang;Username=postgres;Password=23Juni2003");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblBarang>(entity =>
        {
            entity.HasKey(e => e.IdBarang).HasName("tbl_baranf_pkey");

            entity.ToTable("tbl_barang");

            entity.Property(e => e.IdBarang)
                .HasDefaultValueSql("nextval('tbl_baranf_id_barang_seq'::regclass)")
                .HasColumnName("id_barang");
            entity.Property(e => e.KategoriBarang).HasColumnName("kategori_barang");
            entity.Property(e => e.NamaBarang).HasColumnName("nama_barang");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
