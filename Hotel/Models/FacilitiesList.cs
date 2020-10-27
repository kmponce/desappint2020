using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class FacilitiesList
    {
        [Key]
        public int FacilityID{get; set;}
        public string FacilityDesc{get; set;}

        public ICollection<RoomsFacilities> RoomsFacilities {get; set;}
    }
}