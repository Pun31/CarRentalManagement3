using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalManagement.Server.Data;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingsController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public BookingsController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: api/Makes
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
		{
			if (_context.Bookings == null)
			{
				return NotFound();
			}
			return await _context.Bookings.ToListAsync();
		}

		// GET: api/Makes/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Booking>> GetBooking(int id)
		{
			if (_context.Bookings == null)
			{
				return NotFound();
			}
			var booking = await _context.Bookings.FindAsync(id);

			if (booking == null)
			{
				return NotFound();
			}

			return booking;
		}

		// PUT: api/Makes/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutBooking(int id, Booking booking)
		{
			if (id != booking.Id)
			{
				return BadRequest();
			}

			_context.Entry(booking).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!BookingExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Makes
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Booking>> PostBooking(Booking booking)
		{
			if (_context.Bookings == null)
			{
				return Problem("Entity set 'ApplicationDbContext.Bookings'  is null.");
			}
			_context.Bookings.Add(booking);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetBooking", new { id = booking.Id }, booking);
		}

		// DELETE: api/Makes/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteBooking(int id)
		{
			if (_context.Bookings == null)
			{
				return NotFound();
			}
			var booking = await _context.Bookings.FindAsync(id);
			if (booking == null)
			{
				return NotFound();
			}

			_context.Bookings.Remove(booking);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool BookingExists(int id)
		{
			return (_context.Bookings?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}