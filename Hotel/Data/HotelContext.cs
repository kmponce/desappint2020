using Hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Data
{
    public class HotelContext : DbContext{
        public HotelContext(DbContextOptions<HotelContext> options)
        : base(options)
        {

        }

        public DbSet<FacilitiesList> FacilitiesLists{get; set;}
        public DbSet<RoomTypes> RoomTypes{get; set;}
        public DbSet<RoomBand> RoomBands{get; set;}
        public DbSet<RoomPrices> RoomPrices{get; set;}
        public DbSet<Room> Rooms{get; set;}
        public DbSet<RoomsFacilities> RoomsFacilities {get; set;}
        public DbSet<Customer> Customers{get; set;}
        public DbSet<Booking> Bookings{get; set;}
        public DbSet<PaymentMethods> PaymentMethods{get; set;}
        public DbSet<Payment> Payments{get; set;}
        public DbSet<Guest> Guests{get; set;}
        public DbSet<BookingRoom> BookingRooms{get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<FacilitiesList>().ToTable("FacilitiesList");
            modelBuilder.Entity<RoomTypes>().ToTable("RoomTypes");
            modelBuilder.Entity<RoomBand>().ToTable("RoomBand");
            modelBuilder.Entity<RoomPrices>().ToTable("RoomPrices");
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<RoomsFacilities>().ToTable("RoomsFacilities");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Booking>().ToTable("Booking");
            modelBuilder.Entity<PaymentMethods>().ToTable("PaymentMethods");
            modelBuilder.Entity<Payment>().ToTable("Payment");
            modelBuilder.Entity<Guest>().ToTable("Guest");
            modelBuilder.Entity<BookingRoom>().ToTable("BookingRoom");

            modelBuilder.Entity<BookingRoom>().HasKey(c=> new{c.BookingID,c.RoomID,c.GuestID});
            modelBuilder.Entity<RoomsFacilities>().HasKey(c=> new {c.RoomID,c.FacilitiesListID});
            
        }        
    }
}