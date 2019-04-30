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
	/// <summary>
	/// xreiazomaste ena kainourgio modelo pou tha kaluptei to Products kai ta ProductMaterial kai
	/// xrhsimopoieitai mono gia thn epikoinwnia View kai Controller (den pernaei autousio sthn vash
	/// opws ginetai sta alla montela)
	/// Opote to class Modelo periexei ena Product kai mia lista me to ti epelexe o xrhsths apo to checkbox list
	/// </summary>
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
			//pairnoume tis listes me ta Categories kai Materials p tha emfanisoume ston xrhsth na epilexei 
			//kai dhmiourgoume to modelo pou tha analabei thn epikoinwnia
			var m = new Modelo
			{
				Product = new Product()
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
				//product.UserUpdated = Guid.NewGuid();
				//ousiastika enwnoume to model.Product.ProductMaterials me to model.SelectedMaterials
				//kai to sprwxnoumes sthn vash kai dhmiourgei mono tou tis eggrafes ston pinaka ProductMaterials
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
			ViewData["MaterialId"] = new SelectList(_context.Materials, "Id", "Name");
			return View(model);
		}

		// GET: Products/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{

			if (id == null)
			{
				return NotFound();
			}

			var m = new Modelo
			{
				Product = new Product(),
			};
			//trabame to Product pou exei h db MAZI me ta ProductMaterial mesw tou .Include (union, join, etc)
			m.Product = (await _context.Products
				.Include(x => x.ProductMaterials)
				.FirstOrDefaultAsync(x => x.Id == id));

			if (m.Product == null || m == null)
			{
				return NotFound();
			}
			//gemizei to modelo.SelectedMaterials me auta pou efere apo thn vash gia na ta steilei sto View
			m.SelectedMaterials = m.Product.ProductMaterials.Select(x => x.MaterialId.ToString()).ToList();

			ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", m.Product.CategoryId);
			ViewData["MaterialId"] = new SelectList(_context.Materials, "Id", "Name");

			return View(m);
		}

		// POST: Products/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, Modelo model)
		{
			if (id != model.Product.Id)
			{
				return NotFound();
			}
			//fernei apo thn vash to Products mazi me ta ProductMaterials alla ta vazei se ena Product m
			var m = (await _context.Products
					.Include(x => x.ProductMaterials)
					.FirstOrDefaultAsync(x => x.Id == id));

			if (m == null)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
				try
				{
					//gemizei to Product m apo to modelo.Product kai 
					//to Product.ProductMaterial me to modelo.SelectedMaterials ta kainourgia pou esteile to View
					m.CategoryId = model.Product.CategoryId;
					m.Description = model.Product.Description;
					m.InventoryQuantity = model.Product.InventoryQuantity;
					m.SerialNumber = model.Product.SerialNumber;
					m.Price = model.Product.Price;
					m.Name = model.Product.Name;
					m.DateUpdated = DateTime.UtcNow;

					m.ProductMaterials = model.SelectedMaterials.Select(x => new ProductMaterial
					{
						MaterialId = int.Parse(x),
						ProductId = model.Product.Id
					}).ToList();


					_context.Update(m);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ProductExists(m.Id))
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

			ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", m.CategoryId);
			ViewData["MaterialId"] = new SelectList(_context.Materials, "Id", "Name");
			return View(m);
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
