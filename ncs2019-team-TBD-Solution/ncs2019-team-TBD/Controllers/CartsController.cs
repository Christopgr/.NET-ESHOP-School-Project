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

		public IActionResult Index()
        {
            return View();
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

			var cp = new CartItem
			{
				ProductId = ProductId,
				CartId = c.Id,
				Quantity = Quantity
			};

			c.CartItems.Add(cp);

			return View(c);
		}
	}

	public class CartProducts {
		public Product Product { get; set; }
		public List<string> SelectedProducts { get; set; }
	}

	
}