using CabBooking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CabBooking.Infrastructure.Data
{
    public class CabBookingDbContext: DbContext
    {
        public CabBookingDbContext(DbContextOptions<CabBookingDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CabType>(ConfigureCabType);
            modelBuilder.Entity<Place>(ConfigurePlace);
            modelBuilder.Entity<Booking>(ConfigureBooking);
            modelBuilder.Entity<BookingHistory>(ConfigureBookingHisrory);

            modelBuilder.Entity<Booking>().HasOne(m => m.FromPlace)
                    .WithMany(t => t.FromBookings)
                    .HasForeignKey(m => m.FromPlaceId)
                    .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Booking>().HasOne(m => m.ToPlace)
                    .WithMany(t => t.ToBookings)
                    .HasForeignKey(m => m.ToPlaceId)
                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookingHistory>().HasOne(m => m.FromPlace)
                    .WithMany(t => t.FromBookingHistories)
                    .HasForeignKey(m => m.FromPlaceId)
                    .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<BookingHistory>().HasOne(m => m.ToPlace)
                    .WithMany(t => t.ToBookingHistories)
                    .HasForeignKey(m => m.ToPlaceId)
                    .OnDelete(DeleteBehavior.Restrict);
        }

        private void ConfigureBookingHisrory(EntityTypeBuilder<BookingHistory> builder)
        {
            builder.ToTable("BookingHistory");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Email).HasMaxLength(50);
            builder.Property(b => b.BookingTime).HasMaxLength(5);
            builder.Property(b => b.PickupAddress).HasMaxLength(200);
            builder.Property(b => b.Landmark).HasMaxLength(30);
            builder.Property(b => b.PickupTime).HasMaxLength(5);
            builder.Property(b => b.ContactNo).HasMaxLength(25);
            builder.Property(b => b.Status).HasMaxLength(30);
            builder.Property(b => b.CompTime).HasMaxLength(5);
            builder.Property(b => b.Feedback).HasMaxLength(1000);
        }

        private void ConfigureBooking(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Booking");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Email).HasMaxLength(50);
            builder.Property(b => b.BookingTime).HasMaxLength(5);
            builder.Property(b => b.PickupAddress).HasMaxLength(200);
            builder.Property(b => b.Landmark).HasMaxLength(30);
            builder.Property(b => b.PickupTime).HasMaxLength(5);
            builder.Property(b => b.ContactNo).HasMaxLength(25);
            builder.Property(b => b.Status).HasMaxLength(30);

        }

        private void ConfigurePlace(EntityTypeBuilder<Place> builder
            )
        {
            builder.ToTable("Place");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(30);
        }

        private void ConfigureCabType(EntityTypeBuilder<CabType> builder)
        {
            builder.ToTable("CabType");
            builder.HasKey(ct => ct.Id);
            builder.Property(ct => ct.Name).HasMaxLength(30);
        }

        public DbSet<CabType> CabTypes { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingHistory> BookingHistories { get; set; }
    }
}
