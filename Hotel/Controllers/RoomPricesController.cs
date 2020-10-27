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
    public class RoomPricesController : Controller
    {
        private readonly HotelContext _context;

        public RoomPricesController(HotelContext context)
        {
            _context = context;
        }

        // GET: RoomPrices
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoomPrices.ToListAsync());
        }

        // GET: RoomPrices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomPrices = await _context.RoomPrices
                .FirstOrDefaultAsync(m => m.RoomPriceID == id);
            if (roomPrices == null)
            {
                return NotFound();
            }

            return View(roomPrices);
        }

        // GET: RoomPrices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomPrices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomPriceID,RoomPrice")] RoomPrices roomPrices)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomPrices);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomPrices);
        }

        // GET: RoomPrices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomPrices = await _context.RoomPrices.FindAsync(id);
            if (roomPrices == null)
            {
                return NotFound();
            }
            return View(roomPrices);
        }

        // POST: RoomPrices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomPriceID,RoomPrice")] RoomPrices roomPrices)
        {
            if (id != roomPrices.RoomPriceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomPrices);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomPricesExists(roomPrices.RoomPriceID))
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
            return View(roomPrices);
        }

        // GET: RoomPrices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomPrices = await _context.RoomPrices
                .FirstOrDefaultAsync(m => m.RoomPriceID == id);
            if (roomPrices == null)
            {
                return NotFound();
            }

            return View(roomPrices);
        }

        // POST: RoomPrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomPrices = await _context.RoomPrices.FindAsync(id);
            _context.RoomPrices.Remove(roomPrices);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomPricesExists(int id)
        {
            return _context.RoomPrices.Any(e => e.RoomPriceID == id);
        }
    }
}
