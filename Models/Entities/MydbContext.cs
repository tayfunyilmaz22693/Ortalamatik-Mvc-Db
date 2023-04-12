using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ortalama.Models.Entities;

public partial class MydbContext : DbContext
{
    public MydbContext()
    {
    }

    public MydbContext(DbContextOptions<MydbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Lesson> Lessons { get; set; }

    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=mydb;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_turkish_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("lessons");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned zerofill")
                .HasColumnName("id");
            entity.Property(e => e.LessonName).HasMaxLength(50);
            entity.Property(e => e.LessonNote)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
        });

       

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
