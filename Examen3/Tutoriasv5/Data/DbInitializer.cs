using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tutorias.Models;

namespace Tutorias.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TutorialContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Student.
            if (context.Students.Any())
            {
                return;   // DB0000 has been seeded
            }

            var courseList = new CourseList[]
            {
                new CourseList{CourseID=1010,CourseDescription="Matematicas para dummies", CourseCost=500,CourseDurationYears=1,Notes="Desde algebra hasta cosas mas chidoris"},
                new CourseList{CourseID=2020,CourseDescription="Curso para pasar Ceneval", CourseCost=700,CourseDurationYears=1,Notes="Asegurando el futuro de Mx"},
                new CourseList{CourseID=3030,CourseDescription="¿Que es el reversing?", CourseCost=400,CourseDurationYears=2,Notes=""},
                new CourseList{CourseID=4040,CourseDescription="Curso de ingles avanzado", CourseCost=1000,CourseDurationYears=3,Notes="How to say?"},
                new CourseList{CourseID=5050,CourseDescription="Sobre fotografia y otros hobbies", CourseCost=2000,CourseDurationYears=2,Notes="Como ganar dinero desde la comodidad de tus hobbies"},
                new CourseList{CourseID=6060,CourseDescription="Meaching Learning para principiantes", CourseCost=200,CourseDurationYears=0,Notes="Lo facinante del Deep Learning"}
            };

            foreach (CourseList c in courseList)
            {
                context.CourseLists.Add(c);
            }
            context.SaveChanges();

            var empJobPosition = new EmpJobPosition[]
            {
                new EmpJobPosition{EmpPosition="Tutor principal"},
                new EmpJobPosition{EmpPosition="Ponente principal"},
                new EmpJobPosition{EmpPosition="Tutor de soporte"},
                new EmpJobPosition{EmpPosition="Ponente de soporte"},
                new EmpJobPosition{EmpPosition="Tutor secundario"},
            };

            foreach(EmpJobPosition e in empJobPosition)
            {
                context.EmpJobPositions.Add(e);
            }
            context.SaveChanges();

            var contactType = new ContactType[]
            {
                new ContactType{Contact_Type="Telefono"},
                new ContactType{Contact_Type="Celular"},
                new ContactType{Contact_Type="Email"},
                new ContactType{Contact_Type="Presencial"}
            };

            foreach(ContactType c in contactType)
            {
                context.ContactTypes.Add(c);
            }
            context.SaveChanges();

            var employee = new Employee[]
            {
                new Employee{EmpName="Karla", EmpJobPositionID=1,EmpPassword="chachacha",Access="Sure"},
                new Employee{EmpName="Margarita", EmpJobPositionID=2,EmpPassword="123456",Access="noforSure"},
                new Employee{EmpName="Princesa Fiona de Encantador", EmpJobPositionID=3,EmpPassword="654321",Access="accepted"},
                new Employee{EmpName="PezKoi", EmpJobPositionID=4,EmpPassword="passwordnosure",Access="denegated"},
                new Employee{EmpName="Faty", EmpJobPositionID=5,EmpPassword="ilovecampechanas",Access="aynose"},
            };

            foreach(Employee e in employee)
            {
                context.Employees.Add(e);
            }
            context.SaveChanges();

            var student = new Student[]
            {
                new Student{Title="Sr.",FirstName="Guaco",LastName="Warner",Address1="Av siempre viva",Address2="dir de la uni",City="Zacatecas",
                County="Zacatecas", PostCode="98000", Country="Mx",Telephone="4921002010",AltTelephone="4922002030",EmailAddress="warnerbro1@mail.com",
                DOB=DateTime.Parse("1990-01-02"),Enrolled=DateTime.Parse("2020-08-10"), LastChanged=DateTime.Parse("2020-08-06"),UpdateBy="Karla"},
                new Student{Title="Sr.",FirstName="Yaco",LastName="Warner",Address1="Av siempre viva",Address2="dir de la uni",City="Zacatecas",
                County="Zacatecas", PostCode="98000", Country="Mx",Telephone="4921002020",AltTelephone="4922002050",EmailAddress="warneryomm@mail.com",
                DOB=DateTime.Parse("1991-01-02"),Enrolled=DateTime.Parse("2020-08-10"), LastChanged=DateTime.Parse("2020-08-06"),UpdateBy="Faty"},
                new Student{Title="Srita",FirstName="Dot",LastName="Warner",Address1="Av siempre viva",Address2="dir de la uni",City="Zacatecas",
                County="Zacatecas", PostCode="98000", Country="Mx",Telephone="4921002030",AltTelephone="4922002070",EmailAddress="warnerdot@mail.com",
                DOB=DateTime.Parse("1992-01-02"),Enrolled=DateTime.Parse("2020-08-10"), LastChanged=DateTime.Parse("2020-08-06"),UpdateBy="Karla"},
                new Student{Title="Sr.",FirstName="Mushu",LastName="Fa",Address1="Av siempre viva",Address2="dir de la uni",City="Zacatecas",
                County="Omashu", PostCode="56000", Country="China",Telephone="4921002040",AltTelephone="",EmailAddress="deshonor@mail.com",
                DOB=DateTime.Parse("1990-11-12"),Enrolled=DateTime.Parse("2020-09-11"), LastChanged=DateTime.Parse("2020-09-06"),UpdateBy="Fiona"},
            };
            
            foreach(Student s in student)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var student_Course = new Student_Course[]
            {
                new Student_Course{StudentID=1, CourseID=2020,CourseStartDate=DateTime.Parse("2020-08-15"),CourseComplete=false},
                new Student_Course{StudentID=2, CourseID=2020,CourseStartDate=DateTime.Parse("2020-08-15"),CourseComplete=false},
                new Student_Course{StudentID=3, CourseID=2020,CourseStartDate=DateTime.Parse("2020-08-15"),CourseComplete=false},
                new Student_Course{StudentID=3, CourseID=3030,CourseStartDate=DateTime.Parse("2020-08-15"),CourseComplete=false},
                new Student_Course{StudentID=2, CourseID=4040,CourseStartDate=DateTime.Parse("2020-08-15"),CourseComplete=false},
                new Student_Course{StudentID=1, CourseID=1010,CourseStartDate=DateTime.Parse("2020-08-15"),CourseComplete=false}
            };
            foreach(Student_Course s in student_Course)
            {
                context.Student_Courses.Add(s);
            }
            context.SaveChanges();

            var contact = new Contact[]
            {
                new Contact{StudentID=1, ContactTypeID=2, ContactDate=DateTime.Parse("2020-08-20"),EmployeeID=3,ContactDetails="De preferencia por la tarde"},
                new Contact{StudentID=2, ContactTypeID=1, ContactDate=DateTime.Parse("2020-09-20"),EmployeeID=2,ContactDetails="De preferencia por la tarde noche"},
                new Contact{StudentID=3, ContactTypeID=3, ContactDate=DateTime.Parse("2020-10-20"),EmployeeID=1,ContactDetails="En la mañanita"}
            };
            foreach(Contact c in contact)
            {
                context.Contacts.Add(c);
            }
            context.SaveChanges();
        }
    }
}