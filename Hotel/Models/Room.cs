using System;
using System.Collections.Generic;
namespace Hotel.Models
{
    public class Room
    {
        public int RoomID{get; set;}
        public int RoomTypesID{get; set;}
        public int RoomBandID{get; set;}
        public int RoomPricesID{get; set;}
        public string Floor{get; set;}
        public string AdditionalNotes{get; set;}

        
        public RoomTypes RoomTypes{get; set;}
        public RoomBand RoomBand{get; set;}
        public RoomPrices RoomPrices{get; set;}
        public ICollection<RoomsFacilities> RoomsFacilities {get; set;}
        public ICollection<Booking> Bookings{get; set;}
    }
}