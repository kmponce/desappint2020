using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tutorias.Models
{
    public class CourseList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID{get; set;}
        [Column("Description")]
        [Display(Name="Description")]
        public string CourseDescription{get; set;}
        [DataType(DataType.Currency)]
        [Column(TypeName="Cost")]
        [Display(Name="Cost")]
        public decimal CourseCost{get; set;}
        [Range(0,5)]
        [Column("Duration")]
        [Display(Name="Duration(Years)")]
        public int CourseDurationYears{get; set;}
        [StringLength(500)]
        public string Notes{get; set;}

        /****************** Relaciones ***************/
        public ICollection<Student_Course> Student_Courses{get; set;} //uno a muchos
    }
}