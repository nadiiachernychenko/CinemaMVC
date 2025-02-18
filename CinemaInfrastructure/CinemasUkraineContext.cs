using System;
using System.Collections.Generic;
using CinemaDomain.Model;
using Microsoft.EntityFrameworkCore;

namespace CinemaInfrastructure;

public partial class CinemasUkraineContext : DbContext
{
    public CinemasUkraineContext()
    {
    }

    public CinemasUkraineContext(DbContextOptions<CinemasUkraineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Cinema> Cinemas { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=WIN-MLT5J758EBT\\SQLEXPRESS; Database=Cinemas Ukraine; Trusted_Connection=True; TrustServerCertificate=True; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BkId);

            entity.ToTable("BOOKINGS");

            entity.Property(e => e.BkId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("BK_ID");
            entity.Property(e => e.BkDate)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("BK_DATE");
            entity.Property(e => e.BkSeats)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("BK_SEATS");
            entity.Property(e => e.BkSessionId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("BK_SESSION_ID");
            entity.Property(e => e.BkUserId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("BK_USER_ID");

            entity.HasOne(d => d.BkSession).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.BkSessionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BOOKINGS_SESSIONS");

            entity.HasOne(d => d.BkUser).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.BkUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BOOKINGS_USERS1");
        });

        modelBuilder.Entity<Cinema>(entity =>
        {
            entity.HasKey(e => e.CnId);

            entity.ToTable("CINEMAS");

            entity.Property(e => e.CnId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("CN_ID");
            entity.Property(e => e.CnAddress)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("CN_ADDRESS");
            entity.Property(e => e.CnName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("CN_NAME");

            entity.HasOne(d => d.CnNameNavigation).WithMany(p => p.Cinemas)
                .HasForeignKey(d => d.CnName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CINEMAS_CITIES");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CtId);

            entity.ToTable("CITIES");

            entity.Property(e => e.CtId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("CT_ID");
            entity.Property(e => e.CtName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("CT_NAME");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.MvId);

            entity.ToTable("MOVIES");

            entity.Property(e => e.MvId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MV_ID");
            entity.Property(e => e.MvDescription)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MV_DESCRIPTION");
            entity.Property(e => e.MvDuration)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MV_DURATION");
            entity.Property(e => e.MvName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MV_NAME");
            entity.Property(e => e.MvReleaseYear)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MV_RELEASE_YEAR");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.SssId);

            entity.ToTable("SESSIONS");

            entity.Property(e => e.SssId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("SSS_ID");
            entity.Property(e => e.SssCinemaId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("SSS_CINEMA_ID");
            entity.Property(e => e.SssMovieId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("SSS_MOVIE_ID");
            entity.Property(e => e.SssPrice)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("SSS_PRICE");
            entity.Property(e => e.SssTime)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("SSS_TIME");

            entity.HasOne(d => d.SssCinema).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.SssCinemaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SESSIONS_CINEMAS");

            entity.HasOne(d => d.SssMovie).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.SssMovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SESSIONS_MOVIES");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UsId);

            entity.ToTable("USERS");

            entity.Property(e => e.UsId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("US_ID");
            entity.Property(e => e.UsEmail)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("US_EMAIL");
            entity.Property(e => e.UsName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("US_NAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
