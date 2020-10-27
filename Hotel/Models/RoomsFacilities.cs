using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class RoomsFacilities
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoomID{get; set;}
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FacilitiesListID{get; set;}
        public string FacilityDetails{get; set;}

        public FacilitiesList FacilitiesList{get; set;}
        public Room Room{get; set;}
    }
}