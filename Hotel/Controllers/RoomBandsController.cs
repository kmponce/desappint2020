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
    public class RoomBandsController : Controller
    {
        private readonly HotelContext _context;

        public RoomBandsController(HotelContext context)
        {
            _context = context;
        }

        // GET: RoomBands
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoomBands.ToListAsync());
        }

        // GET: RoomBands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomBand = await _context.RoomBands
                .FirstOrDefaultAsync(m => m.RoomBandID == id);
            if (roomBand == null)
            {
                return NotFound();
            }

            return View(roomBand);
        }

        // GET: RoomBands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomBands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomBandID,BandDesc")] RoomBand roomBand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomBand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomBand);
        }

        // GET: RoomBands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomBand = await _context.RoomBands.FindAsync(id);
            if (roomBand == null)
            {
                return NotFound();
            }
            return View(roomBand);
        }

        // POST: RoomBands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomBandID,BandDesc")] RoomBand roomBand)
        {
            if (id != roomBand.RoomBandID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomBand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomBandExists(roomBand.RoomBandID))
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
            return View(roomBand);
        }

        // GET: RoomBands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomBand = await _context.RoomBands
                .FirstOrDefaultAsync(m => m.RoomBandID == id);
            if (roomBand == null)
            {
                return NotFound();
            }

            return View(roomBand);
        }

        // POST: RoomBands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomBand = await _context.RoomBands.FindAsync(id);
            _context.RoomBands.Remove(roomBand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomBandExists(int id)
        {
            return _context.RoomBands.Any(e => e.RoomBandID == id);
        }
    }
}
