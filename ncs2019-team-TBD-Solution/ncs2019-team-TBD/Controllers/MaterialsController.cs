using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ncs2019_team_TBD.Data;
using ncs2019_team_TBD.Models;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ncs2019_team_TBD.Controllers
{
	public class MaterialsController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<User> _userManager;

		public MaterialsController(ApplicationDbContext context, UserManager<User> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		// GET: Materials
		public async Task<IActionResult> Index()
		{
			return View(await _context.Materials.ToListAsync());
		}

		public async Task<IActionResult> GetProducts(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var m = await _context.Materials.Include(p => p.ProductMaterials).ThenInclude(u => u.Product).FirstOrDefaultAsync(x => x.Id == id);

			if (m == null)
			{
				return NotFound();
			}

			return View(m);
		}

		// GET: Materials/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var material = await _context.Materials
				.FirstOrDefaultAsync(m => m.Id == id);
			if (material == null)
			{
				return NotFound();
			}

			return View(material);
		}

		// GET: Materials/Create
		 
		public IActionResult Create()
		{
			return View();
		}

		// POST: Materials/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		 
		public async Task<IActionResult> Create([Bind("Id,Name")] Material material) //,DateCreated,DateUpdated,UserCreated,UserUpdated
		{
			if (ModelState.IsValid)
			{
				var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

				material.DateCreated = DateTime.UtcNow;
				material.DateUpdated = DateTime.UtcNow;

				material.UserCreated = userId;
				material.UserUpdated = userId;

				_context.Add(material);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}


			return View(material);
		}

		// GET: Materials/Edit/5
		 
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var material = await _context.Materials.FindAsync(id);
			if (material == null)
			{
				return NotFound();
			}

			return View(material);
		}

		// POST: Materials/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		 
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Material material) //,DateCreated,DateUpdated,UserCreated,UserUpdated
		{
			if (id != material.Id)
			{
				return NotFound();
			}

			var existing = await _context.Materials.FindAsync(id);

			if (existing == null)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

					existing.DateUpdated = DateTime.UtcNow;
					existing.Name = material.Name;
					existing.UserUpdated = userId;

					_context.Update(existing);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!MaterialExists(existing.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Edit));
			}
			return View(existing);
		}

		// GET: Materials/Delete/5
		 
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var material = await _context.Materials
				.FirstOrDefaultAsync(m => m.Id == id);
			if (material == null)
			{
				return NotFound();
			}

			return View(material);
		}

		// POST: Materials/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		 
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var material = await _context.Materials.FindAsync(id);
			_context.Materials.Remove(material);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool MaterialExists(int id)
		{
			return _context.Materials.Any(e => e.Id == id);
		}
	}
}
