using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalManagement.Server.Data;
using CarRentalManagement.Shared.Domain;
using System.Drawing;

namespace CarRentalManagement.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ColoursController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public ColoursController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: api/Makes
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Colour>>> GetColours()
		{
			if (_context.Colours == null)
			{
				return NotFound();
			}
			return await _context.Colours.ToListAsync();
		}

		// GET: api/Makes/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Colour>> GetColour(int id)
		{
			if (_context.Colours == null)
			{
				return NotFound();
			}
			var colour = await _context.Colours.FindAsync(id);

			if (colour == null)
			{
				return NotFound();
			}

			return colour;
		}

		// PUT: api/Makes/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutColour(int id, Colour colour)
		{
			if (id != colour.Id)
			{
				return BadRequest();
			}

			_context.Entry(colour).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ColourExists(id))
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
		public async Task<ActionResult<Colour>> PostColour(Colour colour)
		{
			if (_context.Colours == null)
			{
				return Problem("Entity set 'ApplicationDbContext.Colours'  is null.");
			}
			_context.Colours.Add(colour);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetColour", new { id = colour.Id }, colour);
		}

		// DELETE: api/Makes/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteColour(int id)
		{
			if (_context.Colours == null)
			{
				return NotFound();
			}
			var colour = await _context.Colours.FindAsync(id);
			if (colour == null)
			{
				return NotFound();
			}

			_context.Colours.Remove(colour);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool ColourExists(int id)
		{
			return (_context.Colours?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}