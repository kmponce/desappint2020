using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Payment
    {
        public int PaymentID{get; set;}
        [Display(Name="Booking")]
        public int BookingID{get; set;}
        [Display(Name="Customer")]
        public int CustomerID{get; set;}
        [Display(Name="PYMT Method")]
        public int PaymentMethodsID{get; set;}
        [Display(Name="PYMT Amount")]
        public decimal PaymentAmount{get; set;}
        [StringLength(500)]
        [Display(Name="PYMT Comments")]
        public string PaymentComments{get; set;}

        public Booking Booking{get; set;}
        public Customer Customer{get; set;}
        public PaymentMethods PaymentMethods{get; set;}
    }
}