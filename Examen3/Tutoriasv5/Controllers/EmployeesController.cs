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
    public class EmployeesController : Controller
    {
        private readonly TutorialContext _context;

        public EmployeesController(TutorialContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index(string searchString)
        {
            var _employees = _context.Employees
                .Include(p=>p.EmpJobPosition)
                .Include(i=>i.Contacts)
                    .ThenInclude(i=>i.Student)
                .AsNoTracking();
            
            var employees =from e in _employees select e;

            if(!string.IsNullOrEmpty(searchString)){
                employees = employees.Where(e=> e.EmpName.Contains(searchString));
            }
            return View(await employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _employees = _context.Employees
                .Include(p=>p.EmpJobPosition)
                .AsNoTracking();
            var employee = await _employees
                .FirstOrDefaultAsync(m => m.EmpID == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            PopulatePositionDropDownList();
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpID,EmpName,EmpJobPositionID,EmpPassword,Access")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulatePositionDropDownList();
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            PopulatePositionDropDownList(id);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpID,EmpName,EmpJobPositionID,EmpPassword,Access")] Employee employee)
        {
            if (id != employee.EmpID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmpID))
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
            PopulatePositionDropDownList(id);
            return View(employee);
        }

        private void PopulatePositionDropDownList(object selectedEmpJobPosition=null)
        {
            var empJobPositionQuery = from p in _context.EmpJobPositions
                orderby p.EmpPosition
                select p;
            ViewBag.EmpJobPositionID = new SelectList(empJobPositionQuery.AsNoTracking(),"EmpJobPositionID","EmpPosition",selectedEmpJobPosition);
        }
        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var _employees = _context.Employees
                .Include(p=>p.EmpJobPosition)
                .AsNoTracking();

            var employee = await _employees
                .FirstOrDefaultAsync(m => m.EmpID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmpID == id);
        }
    }
}
