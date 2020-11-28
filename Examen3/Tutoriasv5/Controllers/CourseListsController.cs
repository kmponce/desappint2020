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
    public class CourseListsController : Controller
    {
        private readonly TutorialContext _context;

        public CourseListsController(TutorialContext context)
        {
            _context = context;
        }

        // GET: CourseLists
        public async Task<IActionResult> Index(string searchString)
        {
            var courses = from c in _context.CourseLists select c;

            if(!string.IsNullOrEmpty(searchString)){
                courses=courses.Where(c=> c.CourseDescription.Contains(searchString));
            }
            return View(await courses.ToListAsync());
        }

        // GET: CourseLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseList = await _context.CourseLists
                .FirstOrDefaultAsync(m => m.CourseID == id);
            if (courseList == null)
            {
                return NotFound();
            }
            return View(courseList);
        }

        // GET: CourseLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CourseLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseID,CourseDescription,CourseCost,CourseDurationYears,Notes")] CourseList courseList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courseList);
        }

        // GET: CourseLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseList = await _context.CourseLists.FindAsync(id);
            if (courseList == null)
            {
                return NotFound();
            }
            return View(courseList);
        }

        // POST: CourseLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseID,CourseDescription,CourseCost,CourseDurationYears,Notes")] CourseList courseList)
        {
            if (id != courseList.CourseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseListExists(courseList.CourseID))
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
            return View(courseList);
        }

        // GET: CourseLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseList = await _context.CourseLists
                .FirstOrDefaultAsync(m => m.CourseID == id);
            if (courseList == null)
            {
                return NotFound();
            }

            return View(courseList);
        }

        // POST: CourseLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseList = await _context.CourseLists.FindAsync(id);
            _context.CourseLists.Remove(courseList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseListExists(int id)
        {
            return _context.CourseLists.Any(e => e.CourseID == id);
        }
    }
}
