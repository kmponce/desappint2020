using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tutorias.Data;
using Tutorias.Models;

namespace Tutorias.Controllers
{
    public class Student_CoursesController : Controller
    {
        private readonly TutorialContext _context;

        public Student_CoursesController(TutorialContext context)
        {
            _context = context;
        }

        // GET: Student_Courses
        public async Task<IActionResult> Index(string searchString)
        {
            var _student_Courses = _context.Student_Courses
                .Include(s => s.Student)
                .Include(s => s.CourseList)
            .AsNoTracking();
            var student_Courses= from f in _student_Courses select f;
            if(!string.IsNullOrEmpty(searchString)){
                student_Courses= student_Courses.Where(c=>c.Student.LastName.Contains(searchString)
                ||c.Student.FirstName.Contains(searchString)
                ||c.CourseList.CourseDescription.Contains(searchString));
            }
            return View(await student_Courses.ToListAsync());
        }

        // GET: Student_Courses/Details/5
        public async Task<IActionResult> Details(int? id, int? id2, DateTime? id3)
        {
            if (id == null || id2 == null || id3 == null)
            {
                return NotFound();
            }

            var student_Course = await _context.Student_Courses
                .FirstOrDefaultAsync(m => m.StudentID == id&&m.CourseID==id2&&DateTime.Equals(m.CourseStartDate, id3));
            if (student_Course == null)
            {
                return NotFound();
            }

            return View(student_Course);
        }

        // GET: Student_Courses/Create
        public IActionResult Create()
        {
            PopulateStudentDropDownList();
            PopulateCourseListDropDownList();
            return View();
        }

        // POST: Student_Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentID,CourseID,CourseStartDate,CourseComplete")] Student_Course student_Course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student_Course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateStudentDropDownList();
            PopulateCourseListDropDownList();
            return View(student_Course);
        }

        // GET: Student_Courses/Edit/5
        public async Task<IActionResult> Edit(int? id,int? id2,DateTime id3)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_Course = await _context.Student_Courses.FindAsync(id,id2,id3);
            if (student_Course == null)
            {
                return NotFound();
            }
            return View(student_Course);
        }

        // POST: Student_Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("StudentID,CourseID,CourseStartDate,CourseComplete")] Student_Course student_Course)
        {
            if (id != student_Course.StudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student_Course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Student_CourseExists(student_Course.StudentID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student_Course);
        }
        private void PopulateStudentDropDownList(object selectedStudent=null)
        {
            var studentQuery = from s in _context.Students
                orderby s.LastName
                select s;
            ViewBag.StudentID = new SelectList(studentQuery.AsNoTracking(),"StudentID","FullName",selectedStudent);
        }
        private void PopulateCourseListDropDownList(object selectedCourseList=null)
        {
            var courseQuery = from c in _context.CourseLists
                orderby c.CourseDescription
                select c;
            ViewBag.CourseID = new SelectList(courseQuery.AsNoTracking(),"CourseID","CourseDescription",selectedCourseList);
        }
        // GET: Student_Courses/Delete/5
        public async Task<IActionResult> Delete(int? id, int? id2, DateTime? id3)
        {
            if (id == null || id2 == null || id3 == null)
            {
                return NotFound();
            }
            
            var student_Course = await _context.Student_Courses
                .Include(c=>c.Student)
                .Include(c=>c.CourseList)
                .FirstOrDefaultAsync(m => m.StudentID == id && m.CourseID == id2 && DateTime.Equals(m.CourseStartDate, id3));
            if (student_Course == null)
            {
                return NotFound();
            }
            
            return View(student_Course);
        }

        
        // POST: Student_Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? StudentID, int? CourseID, DateTime? CourseStartDate)
        {
            var student_Course = await _context.Student_Courses.FindAsync(StudentID,CourseID, CourseStartDate);
            _context.Student_Courses.Remove(student_Course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Student_CourseExists(int id)
        {
            return _context.Student_Courses.Any(e => e.StudentID == id);
        }
    }
}
