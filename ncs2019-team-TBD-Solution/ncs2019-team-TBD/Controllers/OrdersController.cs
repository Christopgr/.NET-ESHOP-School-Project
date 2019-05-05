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
	public class OrdersController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<User> _userManager;

		public OrdersController(ApplicationDbContext context, UserManager<User> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		public IActionResult Billing()
		{

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Billing(Order neworder)
		{
			if (ModelState.IsValid)
			{
				var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
				var c = await _context.Carts.Include(x => x.CartItems).ThenInclude(k => k.Product).FirstOrDefaultAsync(u => u.UserId == userId);
				neworder.State = "Getting the Products ready for shipping";
				neworder.UserId = userId;
				neworder.DateCreated = DateTime.UtcNow;
				neworder.DateUpdated = DateTime.UtcNow;
				neworder.UserCreated = userId;
				neworder.UserUpdated = userId;
				neworder.OrderItems = new List<OrderItem>();
				
				foreach (var item in c.CartItems)
				{
					neworder.OrderItems.Add(new OrderItem
					{
						ProductId = item.ProductId,
						Quantity = item.Quantity

					});
					_context.Remove(item);

				}
				_context.Orders.Add(neworder);

				await _context.SaveChangesAsync();

				return RedirectToAction(nameof(Index));

			}
			return View();
		}

		// GET: Orders
		public async Task<IActionResult> Index()
		{
			var applicationDbContext = _context.Orders.Include(o => o.User);
			return View(await applicationDbContext.ToListAsync());
		}

		// GET: Orders/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var order = await _context.Orders
				.Include(o => o.User)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (order == null)
			{
				return NotFound();
			}

			return View(order);
		}

		//// GET: Orders/Create
		//public IActionResult Create()
		//{
		//	ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name");
		//	return View();
		//}

		//// POST: Orders/Create
		//// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> Create([Bind("UserId,Quantity,State,Id,Name")] Order order)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		order.DateCreated = DateTime.UtcNow;
		//		order.DateUpdated = DateTime.UtcNow;
		//		//order.UserCreated = Guid.NewGuid();
		//		//order.UserUpdated = Guid.NewGuid();

		//		_context.Add(order);
		//		await _context.SaveChangesAsync();
		//		return RedirectToAction(nameof(Index));
		//	}
		//	ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", order.UserId);
		//	return View(order);
		//}

		//// GET: Orders/Edit/5
		//public async Task<IActionResult> Edit(int? id)
		//{
		//	if (id == null)
		//	{
		//		return NotFound();
		//	}

		//	var order = await _context.Orders.FindAsync(id);
		//	if (order == null)
		//	{
		//		return NotFound();
		//	}
		//	ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", order.UserId);
		//	return View(order);
		//}

		//// POST: Orders/Edit/5
		//// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> Edit(int id, [Bind("UserId,Quantity,State,Id,Name")] Order order)
		//{
		//	if (id != order.Id)
		//	{
		//		return NotFound();
		//	}

		//	var existing = await _context.Orders.FindAsync(id);

		//	if (existing == null)
		//	{
		//		return NotFound();
		//	}

		//	if (ModelState.IsValid)
		//	{
		//		try
		//		{
		//			existing.DateUpdated = DateTime.UtcNow;

		//			_context.Update(existing);
		//			await _context.SaveChangesAsync();
		//		}
		//		catch (DbUpdateConcurrencyException)
		//		{
		//			if (!OrderExists(order.Id))
		//			{
		//				return NotFound();
		//			}
		//			else
		//			{
		//				throw;
		//			}
		//		}
		//		return RedirectToAction(nameof(Index));
		//	}
		//	ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", order.UserId);
		//	return View(order);
		//}

		// GET: Orders/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var order = await _context.Orders
				.Include(o => o.User)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (order == null)
			{
				return NotFound();
			}

			return View(order);
		}

		// POST: Orders/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var order = await _context.Orders.FindAsync(id);
			_context.Orders.Remove(order);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool OrderExists(int id)
		{
			return _context.Orders.Any(e => e.Id == id);
		}
	}
}
