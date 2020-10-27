using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class Guest
    {
        public int GuestID{get; set;}
        [Display(Name="Title")]
        public string GuestTitle{get; set;}
        [Required]
        [Column("GuestFirstName")]
        [StringLength(50)]
        [Display(Name="First Name")]
        public string GuestForenames{get; set;}
        [Required]
        [Column("GuestLastName")]
        [StringLength(50)]
        [Display(Name="Last Name")]
        public string GuestSurnames{get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        [Display(Name="Date of Born")]
        public DateTime GuestDOB{get; set;}
        [Display(Name="Street")]
        public string GuestAddressStreet{get; set;}
        [Display(Name="Town")]
        public string GuestAddressTown{get; set;}
        [Display(Name="County")]
        public string GuestAddressCounty{get; set;}
        [Display(Name="Postal Code")]
        public string GuestAddressPostalCode{get; set;}
        [Display(Name="Contact Phone")]
        public string GuestContactPhone{get; set;}

        [NotMapped]
        public string FullName => GuestTitle+" "+GuestForenames+", "+GuestSurnames;
        public ICollection<BookingRoom> BookingRooms{get; set;}
    }
}