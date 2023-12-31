﻿using System;
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
	public class ModelsController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public ModelsController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: api/Makes
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Model>>> GetModels()
		{
			if (_context.Models == null)
			{
				return NotFound();
			}
			return await _context.Models.ToListAsync();
		}

		// GET: api/Makes/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Model>> GetModel(int id)
		{
			if (_context.Models == null)
			{
				return NotFound();
			}
			var model = await _context.Models.FindAsync(id);

			if (model == null)
			{
				return NotFound();
			}

			return model;
		}

		// PUT: api/Makes/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutModel(int id, Model model)
		{
			if (id != model.Id)
			{
				return BadRequest();
			}

			_context.Entry(model).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ModelExists(id))
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
		public async Task<ActionResult<Model>> PostModel(Model model)
		{
			if (_context.Models == null)
			{
				return Problem("Entity set 'ApplicationDbContext.Makes'  is null.");
			}
			_context.Models.Add(model);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetModel", new { id = model.Id }, model);
		}

		// DELETE: api/Makes/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteModel(int id)
		{
			if (_context.Models == null)
			{
				return NotFound();
			}
			var model = await _context.Models.FindAsync(id);
			if (model == null)
			{
				return NotFound();
			}

			_context.Models.Remove(model);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool ModelExists(int id)
		{
			return (_context.Models?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}