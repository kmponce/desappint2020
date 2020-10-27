using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class PaymentMethods
    {
        [Key]
        public int PaymentMethodID{get; set;}
        [StringLength(50, MinimumLength=3)]
        [Display(Name="PYMT Method")]
        public string PaymentMethod{get; set;}

        public ICollection<Payment> Payments{get; set;}
    }
}