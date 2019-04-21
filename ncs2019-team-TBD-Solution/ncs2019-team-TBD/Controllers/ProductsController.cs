using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ncs2019_team_TBD.Data;
using ncs2019_team_TBD.Models;

namespace ncs2019_team_TBD.Controllers
{
	public class Modelo
	{
		public Product Product { get; set; }
		public List<string> SelectedMaterials { get; set; }
	}
	/// <summary>
	/// 
	/// </summary>
	public class ProductsController : Controller
	{
		private readonly ApplicationDbContext _context;
		public ProductsController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Products
		public async Task<IActionResult> Index()
		{
			var applicationDbContext = _context.Products.Include(p => p.Category);
			return View(await applicationDbContext.ToListAsync());
		}

		// GET: Products/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var product = await _context.Products
				.Include(p => p.Category)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}

		// GET: Products/Create
		public IActionResult Create()
		{
			ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
			ViewData["MaterialId"] = new SelectList(_context.Materials, "Id", "Name");

			var m = new Modelo
			{
				Product = new Product(),

			};

			return View(m);
		}

		// POST: Products/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Modelo model)
		{
			if (ModelState.IsValid)
			{
				model.Product.DateCreated = DateTime.UtcNow;
				model.Product.DateUpdated = DateTime.UtcNow;
				//product.UserCreated = Guid.NewGuid();
				// product.UserUpdated = Guid.NewGuid();

				model.Product.ProductMaterials = model.SelectedMaterials.Select(x => new ProductMaterial
				{
					MaterialId = int.Parse(x),
					ProductId = model.Product.Id
				}).ToList();

				_context.Add(model.Product);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", model.Product.CategoryId);
			return View(model);
		}

		// GET: Products/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{

			if (id == null)
			{
				return NotFound();
			}

			var product = await _context.Products.FindAsync(id);
			if (product == null)
			{
				return NotFound();
			}
			ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
			return View(product);
		}

		// POST: Products/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("CategoryId,Description,InventoryQuantity,SerialNumber,Price,Id,Name")] Product product)
		{
			if (id != product.Id)
			{
				return NotFound();
			}

			var existing = await _context.Products.FindAsync(id);

			if (existing == null)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
				try
				{
					existing.CategoryId = product.CategoryId;
					existing.Description = product.Description;
					existing.InventoryQuantity = product.InventoryQuantity;
					existing.SerialNumber = product.SerialNumber;
					existing.Price = product.Price;
					existing.Name = product.Name;
					existing.DateUpdated = DateTime.UtcNow;

					_context.Update(existing);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ProductExists(existing.Id))
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
			ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", existing.CategoryId);
			return View(product);
		}

		// GET: Products/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var product = await _context.Products
				.Include(p => p.Category)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}

		// POST: Products/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var product = await _context.Products.FindAsync(id);
			_context.Products.Remove(product);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool ProductExists(int id)
		{
			return _context.Products.Any(e => e.Id == id);
		}
	}
}
