using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TrailAPI.Models;

public partial class CourseworkDbContext : DbContext
{
    public CourseworkDbContext()
    {
    }

    public CourseworkDbContext(DbContextOptions<CourseworkDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Description> Descriptions { get; set; }

    public virtual DbSet<TrailUser> TrailUsers { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            //Enabling Data Annotations
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            entity.HasKey(e => e.TrailID);

            entity.ToTable("Author", "CW2");

            entity.Property(e => e.TrailID).HasColumnName("trailID");
            entity.Property(e => e.author)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("author");
        });

        modelBuilder.Entity<Description>(entity =>
        {
            //Enabling Data Annotations
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            entity.HasKey(e => e.Geohash);

            entity.ToTable("Description", "CW2", tb => tb.HasTrigger("checkDifficultyValid"));

            //Defining Attributes as VARCHAR(255) Length
            entity.Property(e => e.Difficulty)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("difficulty");
            entity.Property(e => e.Info)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("info");

            //Defining Attributes as VARCHAR(11) Length
            entity.Property(e => e.Geohash)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("geohash");
            entity.Property(e => e.PointAgeohash)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("pointAGeohash");
            entity.Property(e => e.PointBgeohash)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("pointBGeohash");
            entity.Property(e => e.PointCgeohash)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("pointCGeohash");
            entity.Property(e => e.PointDgeohash)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("pointDGeohash");


            entity.Property(e => e.Distance).HasColumnName("distance");
            entity.Property(e => e.Duration).HasColumnName("duration");
        });

        modelBuilder.Entity<TrailUser>(entity =>
        {
            //Enabling Data Annotations
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            entity.HasKey(e => new { e.TrailId, e.UserId });

            entity.ToTable("TrailUsers", "CW2");

            entity.Property(e => e.TrailId).HasColumnName("trailID");
            entity.Property(e => e.UserId).HasColumnName("userID");
            entity.Property(e => e.Geohash)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("geohash");

        });

        modelBuilder.Entity<User>(entity =>
        {
            //Enabling Data Annotations
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            entity.ToTable("Users", "CW2");

            entity.Property(e => e.UserId).HasColumnName("userID");

            //Defining Attributes as VARCHAR(255) Length
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("lastName");
        });


        /************ Custom Models Used for Creating and Updating specific attributes of the corresponding Models **********************/

        //Doesn't link to any model so far
        modelBuilder.Entity<CreateAuthor>(entity =>
        {
            //Enabling Data Annotations
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            //Assigning which table this relates too
            //entity.ToTable("Author", "CW2");

            //Defining Author Attribute
            entity.Property(e => e.author)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("author");
        });

        //Doesn't link to any model so far
        modelBuilder.Entity<CreateUser>(entity =>
        {
            //Enabling Data Annotations
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            //Defining Author Attribute as VARCHAR(255) Length
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("lastName");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}