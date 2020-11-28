using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tutorias.Models
{
    public class Student
    {
        [Key]
        public int StudentID{get; set;}
        [StringLength(50,MinimumLength=3)]
        public string Title{get; set;}
        [Required]
        [StringLength(50)]
        [Display(Name="First Name")]
        public string FirstName{get; set;}
        [Required]
        [StringLength(50)]
        [Display(Name="Last Name")]
        public string LastName{get; set;}
        [StringLength(50)]
        public string Address1{get; set;}
        [StringLength(50)]
        public string Address2{get; set;}
        public string City{get; set;}
        public string County{get; set;}
        [Display(Name="Post Code")]
        public string PostCode{get; set;}
        public string Country{get; set;}
        [StringLength(10)]
        public string Telephone{get; set;}
        [StringLength(10)]
        public string AltTelephone{get; set;}
        [Display(Name="Email")]
        public string EmailAddress{get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        [Display(Name="Date of birth")]
        public DateTime DOB{get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime Enrolled{get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        [Display(Name="Last Changed")]
        public DateTime LastChanged{get; set;}
        [Display(Name="Update By")]
        public string UpdateBy{get; set;}
        [NotMapped]
        public string FullName => LastName + ", " + FirstName;

        /****************** Relaciones ***************/
        public ICollection<Student_Course> Student_Courses{get; set;} //uno a muchos
        public ICollection<Contact> Contacts{get; set;} //uno a muchos
    }
}