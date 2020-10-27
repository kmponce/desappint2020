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
    public class RoomsController : Controller
    {
        private readonly HotelContext _context;

        public RoomsController(HotelContext context)
        {
            _context = context;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
            var hotelContext = _context.Rooms.Include(r => r.RoomBand).Include(r => r.RoomPrices).Include(r => r.RoomTypes);
            return View(await hotelContext.ToListAsync());
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.RoomBand)
                .Include(r => r.RoomPrices)
                .Include(r => r.RoomTypes)
                .FirstOrDefaultAsync(m => m.RoomID == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            ViewData["RoomBandID"] = new SelectList(_context.RoomBands, "RoomBandID", "RoomBandID");
            ViewData["RoomPricesID"] = new SelectList(_context.RoomPrices, "RoomPriceID", "RoomPriceID");
            ViewData["RoomTypesID"] = new SelectList(_context.RoomTypes, "RoomTypeID", "RoomTypeID");
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomID,RoomTypesID,RoomBandID,RoomPricesID,Floor,AdditionalNotes")] Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomBandID"] = new SelectList(_context.RoomBands, "RoomBandID", "RoomBandID", room.RoomBandID);
            ViewData["RoomPricesID"] = new SelectList(_context.RoomPrices, "RoomPriceID", "RoomPriceID", room.RoomPricesID);
            ViewData["RoomTypesID"] = new SelectList(_context.RoomTypes, "RoomTypeID", "RoomTypeID", room.RoomTypesID);
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            ViewData["RoomBandID"] = new SelectList(_context.RoomBands, "RoomBandID", "RoomBandID", room.RoomBandID);
            ViewData["RoomPricesID"] = new SelectList(_context.RoomPrices, "RoomPriceID", "RoomPriceID", room.RoomPricesID);
            ViewData["RoomTypesID"] = new SelectList(_context.RoomTypes, "RoomTypeID", "RoomTypeID", room.RoomTypesID);
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomID,RoomTypesID,RoomBandID,RoomPricesID,Floor,AdditionalNotes")] Room room)
        {
            if (id != room.RoomID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.RoomID))
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
            ViewData["RoomBandID"] = new SelectList(_context.RoomBands, "RoomBandID", "RoomBandID", room.RoomBandID);
            ViewData["RoomPricesID"] = new SelectList(_context.RoomPrices, "RoomPriceID", "RoomPriceID", room.RoomPricesID);
            ViewData["RoomTypesID"] = new SelectList(_context.RoomTypes, "RoomTypeID", "RoomTypeID", room.RoomTypesID);
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.RoomBand)
                .Include(r => r.RoomPrices)
                .Include(r => r.RoomTypes)
                .FirstOrDefaultAsync(m => m.RoomID == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.RoomID == id);
        }
    }
}
