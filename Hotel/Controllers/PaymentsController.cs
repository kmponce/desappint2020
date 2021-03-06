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
    public class PaymentsController : Controller
    {
        private readonly HotelContext _context;

        public PaymentsController(HotelContext context)
        {
            _context = context;
        }

        // GET: Payments
        public async Task<IActionResult> Index()
        {
            var hotelContext = _context.Payments.Include(p => p.Booking).Include(p => p.Customer).Include(p => p.PaymentMethods);
            return View(await hotelContext.ToListAsync());
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments
                .Include(p => p.Booking)
                .Include(p => p.Customer)
                .Include(p => p.PaymentMethods)
                .FirstOrDefaultAsync(m => m.PaymentID == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Payments/Create
        public IActionResult Create()
        {
            ViewData["BookingID"] = new SelectList(_context.Bookings, "BookingID", "BookingID");
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "CustomerForenames");
            ViewData["PaymentMethodsID"] = new SelectList(_context.PaymentMethods, "PaymentMethodID", "PaymentMethodID");
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentID,BookingID,CustomerID,PaymentMethodsID,PaymentAmount,PaymentComments")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookingID"] = new SelectList(_context.Bookings, "BookingID", "BookingID", payment.BookingID);
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "CustomerForenames", payment.CustomerID);
            ViewData["PaymentMethodsID"] = new SelectList(_context.PaymentMethods, "PaymentMethodID", "PaymentMethodID", payment.PaymentMethodsID);
            return View(payment);
        }

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            ViewData["BookingID"] = new SelectList(_context.Bookings, "BookingID", "BookingID", payment.BookingID);
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "CustomerForenames", payment.CustomerID);
            ViewData["PaymentMethodsID"] = new SelectList(_context.PaymentMethods, "PaymentMethodID", "PaymentMethodID", payment.PaymentMethodsID);
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentID,BookingID,CustomerID,PaymentMethodsID,PaymentAmount,PaymentComments")] Payment payment)
        {
            if (id != payment.PaymentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(payment.PaymentID))
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
            ViewData["BookingID"] = new SelectList(_context.Bookings, "BookingID", "BookingID", payment.BookingID);
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "CustomerForenames", payment.CustomerID);
            ViewData["PaymentMethodsID"] = new SelectList(_context.PaymentMethods, "PaymentMethodID", "PaymentMethodID", payment.PaymentMethodsID);
            return View(payment);
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments
                .Include(p => p.Booking)
                .Include(p => p.Customer)
                .Include(p => p.PaymentMethods)
                .FirstOrDefaultAsync(m => m.PaymentID == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentExists(int id)
        {
            return _context.Payments.Any(e => e.PaymentID == id);
        }
    }
}
