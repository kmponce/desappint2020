using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class Customer
    {
        public int CustomerID{get; set;}
        public string CustomerTitle{get; set;}
        [Required]
        [Column("CustomerFirstName")]
        [StringLength(50)]
        [Display(Name="First Name")]
        public string CustomerForenames{get; set;}
        [Required]
        [Column("CustomerLastName")]
        [StringLength(50)]
        [Display(Name="Last Name")]
        public string CustomerSurnames{get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        [Display(Name="Date of Born")]
        public DateTime CustomerDOB{get; set;}
        [Display(Name="Street")]
        public string CustomerAddressStreet{get; set;}
        [Display(Name="Town")]
        public string CustomerAddressTown{get; set;}
        [Display(Name="County")]
        public string CustomerAddressCounty{get; set;}
        [Display(Name="Postal Code")]
        public string CustomerAddressPostalCode{get; set;}
        [StringLength(10)]
        [Display(Name="Home Phone")]
        public string CustomerHomePhone{get; set;}
        [StringLength(10)]
        [Display(Name="Work Phone")]
        public string CustomerWorkPhone{get; set;}
        [StringLength(10)]
        [Display(Name="Mobile")]
        public string CustomerMobilePhone{get; set;}
        [Display(Name="Email")]
        public string CustomerEmail{get; set;}

        [NotMapped] //No se crea en el modelo de la BD
        public string FullName => CustomerTitle+" "+CustomerForenames + ", " + CustomerSurnames;
        [NotMapped]
        public string FullDirection => CustomerAddressStreet+", "+CustomerAddressTown+", "+CustomerAddressCounty+", C.P. "+CustomerAddressPostalCode;

        public ICollection<Booking> Bookings{get; set;}
        public ICollection<Payment> Payments{get; set;}
    }
}