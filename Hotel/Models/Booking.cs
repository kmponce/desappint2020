using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class Booking
    {
        public int BookingID{get; set;}
        [Display(Name="Customer")]
        public int CustomerID{get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        [Display(Name="Date")]
        public DateTime DateBookingMade{get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:HH:mm}", ApplyFormatInEditMode=true)]
        [Display(Name="Time")]
        public DateTime TimeBookingMade{get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        [Display(Name="Start")]
        public DateTime BookedStartDate{get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        [Display(Name="End")]
        public DateTime BookedEndDate{get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        [Display(Name="Pay Date")]
        public DateTime TotalPaymentDueDate{get; set;}
        [DataType(DataType.Currency)]
        [Display(Name="Total PYMT")]
        public decimal TotalPaymentDueAmount{get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        [Display(Name="PYMT Date")]
        public DateTime TotalPaymentMadeOn{get; set;}
        [Display(Name="Comments")]
        public string BookingComments{get; set;}
        
        public Customer Customer{get; set;}
        public ICollection<BookingRoom> BookingRooms{get; set;}
        public ICollection<Payment> Payments{get; set;}
    }
}