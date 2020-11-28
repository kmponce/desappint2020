using Tutorias.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace Tutorias.Data
{  
    public class TutorialContext:IdentityDbContext<User>
    {
        public TutorialContext(DbContextOptions<TutorialContext> options)
        : base(options)
        {

        }

        public DbSet<CourseList> CourseLists{get; set;}
        public DbSet<Student_Course> Student_Courses{get; set;}
        public DbSet<EmpJobPosition> EmpJobPositions {get; set;}
        public DbSet<Employee> Employees {get; set;}
        public DbSet<ContactType> ContactTypes{get; set;}
        public DbSet<Student> Students{get; set;}
        public DbSet<Contact> Contacts{get; set;} 

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CourseList>().ToTable("CourseList");
            modelBuilder.Entity<Student_Course>().ToTable("Student_Course");
            modelBuilder.Entity<EmpJobPosition>().ToTable("EmpJobPosition");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<ContactType>().ToTable("ContactType");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Contact>().ToTable("Contact");

            modelBuilder.Entity<Student_Course>().HasKey(c=> new{c.StudentID,c.CourseID,c.CourseStartDate});
        }
    }
}