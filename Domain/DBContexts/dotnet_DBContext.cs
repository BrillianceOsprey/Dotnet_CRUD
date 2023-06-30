using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_CRUD.Domain.DBContexts;

public partial class dotnet_DBContext : DbContext
{
    public dotnet_DBContext()
    {
    }

    public dotnet_DBContext(DbContextOptions<dotnet_DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<Kyu> Kyus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SBSDEV-004\\SQLEXPRESS;Database=dotnet-rpg;user=sa;password=12345;trusted_connection=true;encrypt=false;Integrated Security=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Character>(entity =>
        {
            entity.Property(e => e.Id).HasMaxLength(50);
        });

        modelBuilder.Entity<Kyu>(entity =>
        {
            entity.ToTable("Kyu");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("createdOn");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
