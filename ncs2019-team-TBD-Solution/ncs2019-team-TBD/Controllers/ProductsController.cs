using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
		private readonly UserManager<User> _userManager;

		public ProductsController(ApplicationDbContext context, UserManager<User> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		// GET: Products/Add/{productId}&{quantity}
		[HttpPost, ActionName("Add")]
		public async Task<JsonResult> Add([FromBody]addToCartArgs args)
		{
			var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

			var c = await _context.Carts.Include(x => x.CartItems).ThenInclude(k => k.Product).FirstOrDefaultAsync(u => u.UserId == userId);

			var p = await _context.Products.FindAsync(args.productId);
			var item = c.CartItems.Where(x => x.ProductId == args.productId).FirstOrDefault();
			if (p != null)
			{
				if (item != null)
				{
					item.Quantity += args.quantity;

					_context.Update(item);

					await _context.SaveChangesAsync();
				}
				else
				{
					c.CartItems.Add(new CartItem
					{
						ProductId = args.productId,
						Quantity = args.quantity
					});
					await _context.SaveChangesAsync();
				}
				return Json(c.CartItems.Count);
			}

			return Json(0);
		}
		/*if (c.CartItems.Any(x => x.ProductId == productId))
		{
			foreach (var i in c.CartItems)
			{
				if (i.ProductId == productId)
				{
					if (p.InventoryQuantity - quantity < 0)
					{
						return NotFound();
					}
					//else
					//{
					//	p.InventoryQuantity -= quantity;
					//}
					i.Quantity += quantity;
				}
			}

			_context.Update(c);
			//_context.Update(p);

			await _context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}
		else
		{

			//m.ProductMaterials = model.SelectedMaterials.Select(x => new ProductMaterial
			//{
			//	MaterialId = int.Parse(x),
			//	ProductId = model.Product.Id
			//}).ToList();

			if (p.InventoryQuantity - quantity < 0)
			{
				return NotFound();
			} 
			//mono otan ginei to order
			//else
			//{
			//	p.InventoryQuantity -= quantity;
			//}

			var ci = new CartItem
			{
				ProductId = productId,
				CartId = c.Id,
				Quantity = quantity
			};

			c.CartItems.Add(ci);

			_context.Update(c);
			//_context.Update(p);

			await _context.SaveChangesAsync();


		}*/


		// GET: Products
		public async Task<IActionResult> Index()
		{
			var applicationDbContext = _context.Products.Include(p => p.Category);
			return View(await applicationDbContext.ToListAsync());
		}

		public class DetailProd
		{
			public Product prod { get; set; }
			public List<ProductMaterial> matlist = new List<ProductMaterial>();
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

			var dp = new DetailProd { prod = product };

			var product2 = await _context.Products
				.Include(p => p.ProductMaterials)
				.ThenInclude(r => r.Material)
				.FirstOrDefaultAsync(m => m.Id == id);

			dp.matlist = product2.ProductMaterials.ToList();

			return View(dp);
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
				var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

				model.Product.DateCreated = DateTime.UtcNow;
				model.Product.DateUpdated = DateTime.UtcNow;
				model.Product.UserCreated = userId;
				model.Product.UserUpdated = userId;
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
					var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
					//gemizei to Product m apo to modelo.Product kai 
					//to Product.ProductMaterial me to modelo.SelectedMaterials ta kainourgia pou esteile to View
					m.CategoryId = model.Product.CategoryId;
					m.Description = model.Product.Description;
					m.InventoryQuantity = model.Product.InventoryQuantity;
					m.SerialNumber = model.Product.SerialNumber;
					m.Price = model.Product.Price;
					m.Name = model.Product.Name;
					m.DateUpdated = DateTime.UtcNow;
					m.UserUpdated = userId;

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

	public class addToCartArgs
	{
		public int productId { get; set; }
		public int quantity { get; set; }
	}
}
