using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace productospra3.Models;

public partial class BdproductosContext : DbContext
{
    public BdproductosContext()
    {
    }

    public BdproductosContext(DbContextOptions<BdproductosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Productoss> Productosses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
        //    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("server=GALAXY10\\SQLEXPRESS; database=bdproductos; integrated security=true;TrustServerCertificate=True;");

        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Productoss>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__producto__3214EC07C5D5DD4B");

            entity.ToTable("productoss");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
