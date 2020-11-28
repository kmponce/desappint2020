using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tutorias.Models
{
    public class EmpJobPosition
    {
        [Key]
        public int EmpJobPositionID{get; set;}
        [Column("Position")]
        public string EmpPosition{get; set;}

        /****************** Relaciones ***************/
        public ICollection<Employee> Employees{get; set;} //uno a muchos
    }
}