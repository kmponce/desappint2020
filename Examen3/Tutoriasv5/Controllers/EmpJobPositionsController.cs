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
    public class EmpJobPositionsController : Controller
    {
        private readonly TutorialContext _context;

        public EmpJobPositionsController(TutorialContext context)
        {
            _context = context;
        }

        // GET: EmpJobPositions
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmpJobPositions.ToListAsync());
        }

        // GET: EmpJobPositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empJobPosition = await _context.EmpJobPositions
                .FirstOrDefaultAsync(m => m.EmpJobPositionID == id);
            if (empJobPosition == null)
            {
                return NotFound();
            }

            return View(empJobPosition);
        }

        // GET: EmpJobPositions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmpJobPositions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpJobPositionID,EmpPosition")] EmpJobPosition empJobPosition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empJobPosition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empJobPosition);
        }

        // GET: EmpJobPositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empJobPosition = await _context.EmpJobPositions.FindAsync(id);
            if (empJobPosition == null)
            {
                return NotFound();
            }
            return View(empJobPosition);
        }

        // POST: EmpJobPositions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpJobPositionID,EmpPosition")] EmpJobPosition empJobPosition)
        {
            if (id != empJobPosition.EmpJobPositionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empJobPosition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpJobPositionExists(empJobPosition.EmpJobPositionID))
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
            return View(empJobPosition);
        }

        // GET: EmpJobPositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empJobPosition = await _context.EmpJobPositions
                .FirstOrDefaultAsync(m => m.EmpJobPositionID == id);
            if (empJobPosition == null)
            {
                return NotFound();
            }

            return View(empJobPosition);
        }

        // POST: EmpJobPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empJobPosition = await _context.EmpJobPositions.FindAsync(id);
            _context.EmpJobPositions.Remove(empJobPosition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpJobPositionExists(int id)
        {
            return _context.EmpJobPositions.Any(e => e.EmpJobPositionID == id);
        }
    }
}
