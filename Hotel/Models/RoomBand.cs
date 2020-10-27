using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public class RoomBand
    {
        public int RoomBandID{get; set;}
        public string BandDesc{get; set;}

        public ICollection<Room> Rooms {get; set;}
    }
}