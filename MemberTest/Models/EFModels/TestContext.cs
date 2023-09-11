using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MemberTest.Models.EFModels;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("TestDatabase");
            optionsBuilder.UseSqlServer(connectionString, x => x.UseNetTopologySuite());
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Sn);

            entity.Property(e => e.Category)
                .HasMaxLength(10)
                .HasColumnName("CATEGORY");
            entity.Property(e => e.Classid)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CLASSID");
            entity.Property(e => e.Grade1).HasColumnName("GRADE");
            entity.Property(e => e.Studentid)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("STUDENTID");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.Sn);

            entity.ToTable("Member");

            entity.Property(e => e.Birthday).HasColumnType("date");
            entity.Property(e => e.Mail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(10);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
