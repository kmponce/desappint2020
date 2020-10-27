using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class RoomPrices
    {
        [Key]
        public int RoomPriceID{get; set;}
        [DataType(DataType.Currency)]
        public decimal RoomPrice{get; set;}

        public ICollection<Room> Rooms {get; set;}
    }
}