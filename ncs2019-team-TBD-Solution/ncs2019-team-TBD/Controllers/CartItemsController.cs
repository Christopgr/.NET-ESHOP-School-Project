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
	public class CartItemsController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<User> _userManager;



		public CartItemsController(ApplicationDbContext context, UserManager<User> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		//public class ItemProd
		//{
		//	public Cart TempCart { get; set; }
		//	public List<Product> ProductList = new List<Product>();

		//}

		// GET: CartItems
		public async Task<IActionResult> Index()
		{
			var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
			var c = await _context.Carts.Include(x => x.CartItems).ThenInclude(k => k.Product).FirstOrDefaultAsync(u => u.UserId == userId);

			float finalprice = 0;

			foreach (var item in c.CartItems)
			{
				var Price1 = item.Product.Price * item.Quantity;
				finalprice = finalprice + Price1;
			}
			ViewBag.finalprice = finalprice;

			//mporw kai na mhn steilw to Cart

			return View(c);
		}

		// GET: CartItems/Details/5
		public async Task<IActionResult> Details(CartItem cartitem)
		{
			if (cartitem == null)
			{
				return NotFound();
			}

			var cartItem = await _context.CartItems
				.FirstOrDefaultAsync();
			if (cartItem == null)
			{
				return NotFound();
			}

			return RedirectToAction("Details", "Products", new { id = cartItem.ProductId });
		}

		// GET: CartItems/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: CartItems/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("CartId,ProductId,Quantity")] CartItem cartItem)
		{
			if (ModelState.IsValid)
			{
				_context.Add(cartItem);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(cartItem);
		}

		// GET: CartItems/Edit/5
		public async Task<IActionResult> Edit(CartItem cartitem)
		{

			var cartItem = await _context.CartItems.FirstOrDefaultAsync();
			if (cartItem == null)
			{
				return NotFound();
			}
			return View(cartItem);
		}


		// POST: CartItems/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, CartItem cartitem)
		{

			var cartItem = await _context.CartItems.FirstOrDefaultAsync();

			if (cartItem != null)
			{
				try
				{
					cartItem.Quantity = cartitem.Quantity;
					_context.Update(cartItem);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!CartItemExists(cartItem.ProductId))
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
			return View(cartItem);
		}

		// GET: CartItems/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var cartItem = await _context.CartItems
				.FirstOrDefaultAsync(r => r.ProductId == id);
			if (cartItem == null)
			{
				return NotFound();
			}

			return View(cartItem);
		}

		// POST: CartItems/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int? id)
		{
			var cartItem = await _context.CartItems
			   .FirstOrDefaultAsync(r => r.ProductId == id);

			_context.CartItems.Remove(cartItem);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool CartItemExists(int id)
		{
			return _context.CartItems.Any(e => e.ProductId == id);
		}
	}
}
