using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tutorias.Models
{
    public class Employee
    {
        [Key]
        public int EmpID{get; set;}
        [Required]
        [Column("Name")]
        [Display(Name="Name")]
        public string EmpName{get; set;}
        [Display(Name="Position")]
        public int EmpJobPositionID{get; set;}
        [Column("Password")]
        [Display(Name="Password")]
        public string EmpPassword{get; set;}
        public string Access{get; set;}

        /****************** Relaciones ***************/
        public EmpJobPosition EmpJobPosition{get; set;} //muchos a uno
        public ICollection<Contact> Contacts{get; set;} //uno a muchos
    }
}