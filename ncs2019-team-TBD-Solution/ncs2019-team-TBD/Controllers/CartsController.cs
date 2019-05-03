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
			var c = await _context.Carts.Include(ci => ci.CartItems).FirstOrDefaultAsync(x => x.Id == CartId);
			return View(c);
		}
	}
}