using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SmartHotels.Data.Models;

public partial class SmartHotelContext : DbContext
{
    public SmartHotelContext()
    {
    }

    public SmartHotelContext(DbContextOptions<SmartHotelContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Guest>(entity =>
        {
            entity.ToTable("guest");

            entity.Property(e => e.GuestId).HasColumnName("guest_id");
            entity.Property(e => e.Birthdate)
                .HasColumnType("date")
                .HasColumnName("birthdate");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(15)
                .HasColumnName("contact_phone");
            entity.Property(e => e.DocumentNumber)
                .HasMaxLength(20)
                .HasColumnName("document_number");
            entity.Property(e => e.DocumentType)
                .HasMaxLength(3)
                .HasColumnName("document_type");
            entity.Property(e => e.Email)
                .HasMaxLength(70)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(20)
                .HasColumnName("gender");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.UserId)
                .HasMaxLength(30)
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.ToTable("hotel");

            entity.Property(e => e.HotelId).HasColumnName("hotel_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(80)
                .HasColumnName("city");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Stars).HasColumnName("stars");
            entity.Property(e => e.UserId)
                .HasMaxLength(30)
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReserveId);

            entity.ToTable("reservation");

            entity.Property(e => e.ReserveId).HasColumnName("reserve_id");
            entity.Property(e => e.EmergencyContactName)
                .HasMaxLength(100)
                .HasColumnName("emergency_contact_name");
            entity.Property(e => e.EmergencyContactPhone)
                .HasMaxLength(20)
                .HasColumnName("emergency_contact_phone");
            entity.Property(e => e.FromDate)
                .HasColumnType("date")
                .HasColumnName("from_date");
            entity.Property(e => e.GuestIds)
                .HasMaxLength(200)
                .HasColumnName("guest_ids");
            entity.Property(e => e.HotelId).HasColumnName("hotel_id");
            entity.Property(e => e.ReserveAt)
                .HasColumnType("date")
                .HasColumnName("reserve_at");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.ToDate)
                .HasColumnType("date")
                .HasColumnName("to_date");
            entity.Property(e => e.TotalPrice).HasColumnName("total_price");
            entity.Property(e => e.UserId)
                .HasMaxLength(30)
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.ToTable("room");

            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.BasePrice).HasColumnName("base_price");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.HotelId).HasColumnName("hotel_id");
            entity.Property(e => e.Location)
                .HasMaxLength(20)
                .HasColumnName("location");
            entity.Property(e => e.Taxes).HasColumnName("taxes");
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_room_hotel");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
