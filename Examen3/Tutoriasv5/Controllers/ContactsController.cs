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
    public class ContactsController : Controller
    {
        private readonly TutorialContext _context;

        public ContactsController(TutorialContext context)
        {
            _context = context;
        }

        // GET: Contacts
        public async Task<IActionResult> Index(string searchString)
        { 
            var tutorialContext = _context.Contacts
                .Include(c => c.ContactType)
                .Include(c => c.Employee)
                .Include(c => c.Student);
            return View(await tutorialContext.ToListAsync());
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .Include(c => c.ContactType)
                .Include(c => c.Employee)
                .FirstOrDefaultAsync(m => m.ContactID == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            PopulateStudentDropDownList();
            PopulateContactTypeDropDownList();
            PopulateEmployeeDropDownList();
            //ViewData["ContactTypeID"] = new SelectList(_context.ContactTypes, "ContactTypeID", "ContactTypeID");
            //ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmpID", "EmpName");
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactID,StudentID,ContactTypeID,ContactDate,EmployeeID,ContactDetails")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            PopulateStudentDropDownList();
            PopulateContactTypeDropDownList();
            PopulateEmployeeDropDownList();
            //ViewData["ContactTypeID"] = new SelectList(_context.ContactTypes, "ContactTypeID", "ContactTypeID", contact.ContactTypeID);
            //ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmpID", "EmpName", contact.EmployeeID);
            return View(contact);
        }

        // GET: Contacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            
            PopulateStudentDropDownList(id);
            PopulateContactTypeDropDownList(id);
            PopulateEmployeeDropDownList(id);
            //ViewData["ContactTypeID"] = new SelectList(_context.ContactTypes, "ContactTypeID", "ContactTypeID", contact.ContactTypeID);
            //ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmpID", "EmpName", contact.EmployeeID);
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContactID,StudentID,ContactTypeID,ContactDate,EmployeeID,ContactDetails")] Contact contact)
        {
            if (id != contact.ContactID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.ContactID))
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
            
            PopulateStudentDropDownList(id);
            PopulateContactTypeDropDownList(id);
            PopulateEmployeeDropDownList(id);
            //ViewData["ContactTypeID"] = new SelectList(_context.ContactTypes, "ContactTypeID", "ContactTypeID", contact.ContactTypeID);
            //ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmpID", "EmpName", contact.EmployeeID);
            return View(contact);
        }

        private void PopulateEmployeeDropDownList(object selectedEmployee=null)
        {
            var employeeQuery = from e in _context.Employees
                orderby e.EmpName
                select e;
            ViewBag.EmployeeID = new SelectList(employeeQuery.AsNoTracking(),"EmpID","EmpName",selectedEmployee);
            //_context.Employees, "EmpID", "EmpName", contact.EmployeeID
        }
        private void PopulateStudentDropDownList(object selectedStudent=null)
        {
            var studentQuery = from s in _context.Students
                orderby s.LastName
                select s;
            ViewBag.StudentID = new SelectList(studentQuery.AsNoTracking(),"StudentID","FullName",selectedStudent);
        }
        private void PopulateContactTypeDropDownList(object selectedContactType=null)
        {
            var contactQuery = from s in _context.ContactTypes
                orderby s.Contact_Type
                select s;
            ViewBag.ContactTypeID = new SelectList(contactQuery.AsNoTracking(),"ContactTypeID","Contact_Type",selectedContactType);
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .Include(c => c.ContactType)
                .Include(c => c.Employee)
                .FirstOrDefaultAsync(m => m.ContactID == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.ContactID == id);
        }
    }
}
