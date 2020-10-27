using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel.Data;
using Hotel.Models;

namespace Hotel.Controllers
{
    public class FacilitiesListsController : Controller
    {
        private readonly HotelContext _context;

        public FacilitiesListsController(HotelContext context)
        {
            _context = context;
        }

        // GET: FacilitiesLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.FacilitiesLists.ToListAsync());
        }

        // GET: FacilitiesLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facilitiesList = await _context.FacilitiesLists
                .FirstOrDefaultAsync(m => m.FacilityID == id);
            if (facilitiesList == null)
            {
                return NotFound();
            }

            return View(facilitiesList);
        }

        // GET: FacilitiesLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FacilitiesLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FacilityID,FacilityDesc")] FacilitiesList facilitiesList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facilitiesList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(facilitiesList);
        }

        // GET: FacilitiesLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facilitiesList = await _context.FacilitiesLists.FindAsync(id);
            if (facilitiesList == null)
            {
                return NotFound();
            }
            return View(facilitiesList);
        }

        // POST: FacilitiesLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FacilityID,FacilityDesc")] FacilitiesList facilitiesList)
        {
            if (id != facilitiesList.FacilityID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facilitiesList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacilitiesListExists(facilitiesList.FacilityID))
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
            return View(facilitiesList);
        }

        // GET: FacilitiesLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facilitiesList = await _context.FacilitiesLists
                .FirstOrDefaultAsync(m => m.FacilityID == id);
            if (facilitiesList == null)
            {
                return NotFound();
            }

            return View(facilitiesList);
        }

        // POST: FacilitiesLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facilitiesList = await _context.FacilitiesLists.FindAsync(id);
            _context.FacilitiesLists.Remove(facilitiesList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacilitiesListExists(int id)
        {
            return _context.FacilitiesLists.Any(e => e.FacilityID == id);
        }
    }
}
