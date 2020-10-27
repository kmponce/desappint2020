using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class BookingRoom
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name="Booking")]
        public int BookingID{get; set;}
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name="Room")]
        public int RoomID{get; set;}
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name="Guest")]
        public int GuestID{get; set;}

        public Booking Booking{get; set;}
        public Room Room{get; set;}
        public Guest Guest{get; set;}
    }
}