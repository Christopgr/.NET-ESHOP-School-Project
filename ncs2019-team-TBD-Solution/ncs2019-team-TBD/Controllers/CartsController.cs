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
    public class CartsController : Controller
    {
		private readonly ApplicationDbContext _context;
		public CartsController(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index(int CartId)
		{
			var c = _context.Cart.Include(ci => ci.CartItems).FirstOrDefaultAsync(x => x.Id == CartId);
			return View(c);
		}

		//POST
		public async Task<IActionResult> Add(int CartId, int ProductId, int Quantity)
		{
			var c = await _context.Cart
			.Include(x => x.CartItems)
			.FirstOrDefaultAsync(m => m.Id == CartId);

			if (c == null)
			{
				return NotFound();
			}

			var p = await _context.Products.FindAsync(ProductId);

			if (p.InventoryQuantity - Quantity < 0)
			{
				return NotFound();
			}
			else {
				p.InventoryQuantity -= Quantity;
			}

			var ci = new CartItem
			{
				ProductId = ProductId,
				CartId = c.Id,
				Quantity = Quantity
			};

			c.CartItems.Add(ci);

			_context.Add(c);
			_context.Add(p);

			await _context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}
	}	
}