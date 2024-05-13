using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RGMapi.Models.EntityFramework;

public partial class RgmContext : DbContext
{
    public RgmContext()
    {
    }

    public RgmContext(DbContextOptions<RgmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Lien> Liens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;port=5432;Database=RGM; uid=postgres; password=admin;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lien>(entity =>
        {
            entity.HasKey(e => e.Lienid).HasName("lien_pkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
