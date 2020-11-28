using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tutorias.Models
{
    public class Student_Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentID{get; set;}
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID{get; set;}
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        [Display(Name="Start Date")]
        public DateTime CourseStartDate{get; set;}
        public bool CourseComplete{get; set;}

        /****************** Relaciones ***************/
        public CourseList CourseList{get; set;} //muchos a uno
        public Student Student{get; set;}// uno a muchos
    }
}