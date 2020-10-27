using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class RoomTypes
    {
        [Key]
        public int RoomTypeID{get; set;}
        public string RoomType{get; set;}

        public ICollection<Room> Rooms {get; set;}

    }
}