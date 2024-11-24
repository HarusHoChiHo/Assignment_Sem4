using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Q2Lab4.Models;

public partial class BooksDbContext : DbContext
{
    public BooksDbContext()
    {
    }

    public BooksDbContext(DbContextOptions<BooksDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Titles> Titles { get; set; }

    public virtual DbSet<AuthorISBN> AuthorISBN { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\Database\Books.mdf"))};Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AuthorISBN>(entity => 
        {
            entity.HasKey(e => new { e.AuthorId, e.Isbn});
            entity.Property(e => e.Isbn).HasMaxLength(20).IsUnicode(false).HasColumnName("ISBN").IsRequired();
            entity.Property(e => e.AuthorId).HasColumnName("AuthorID").IsRequired();
        });

        modelBuilder.Entity<AuthorISBN>().HasOne<Author>(e => e.Author).WithMany(e => e.AuthorISBNs).HasForeignKey(e => e.AuthorId).HasPrincipalKey(e => e.AuthorId);
        modelBuilder.Entity<AuthorISBN>().HasOne<Titles>(e => e.Titles).WithMany(e => e.AuthorISBNs).HasForeignKey(e => e.Isbn).HasPrincipalKey(e => e.Isbn);

        modelBuilder.Entity<Titles>(entity =>
        {
            entity.HasKey(e => e.Isbn);

            entity.Property(e => e.Isbn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ISBN");
            entity.Property(e => e.Copyright)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
