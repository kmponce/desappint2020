using System;
using System.ComponentModel.DataAnnotations;

namespace Tutorias.Models
{
    public class Contact
    {
        [Key]
        public int ContactID{get; set;}
        public int StudentID{get; set;}
        public int ContactTypeID{get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        [Display(Name="Contact Date")]
        public DateTime ContactDate{get; set;}
        public int EmployeeID{get; set;}
        [StringLength(500)]
        [Display(Name="Contact Details")]
        public string ContactDetails{get; set;}

        /****************** Relaciones ***************/
        public Employee Employee{get; set;} // Muchos a uno
        public ContactType ContactType{get; set;} //Muchos a uno
        public Student Student{get; set;} // Uno a muchos
    }
}