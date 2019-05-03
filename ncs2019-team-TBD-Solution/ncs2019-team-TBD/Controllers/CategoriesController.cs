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
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
		private readonly UserManager<User> _userManager;

		public CategoriesController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
			_userManager = userManager;
        }

		public async Task<IActionResult> GetProducts(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var c = await _context.Categories.Include(p => p.Products).FirstOrDefaultAsync(x=>x.Id == id);

			if (c == null)
			{
				return NotFound();
			}

			return View(c);
		}

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            //var categories = await _context.Categories.Include(p => p.Products).ToListAsync();
            var categories = await _context.Categories.ToListAsync();
			return View(categories);
        }

        

        public async Task<IActionResult> GetProducts(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var c = await _context.Categories.Include(p => p.Products).FirstOrDefaultAsync(x => x.Id == id);

            if (c == null)
            {
                return NotFound();
            }

            return View(c);
            //ViewData["View Products"]=c;
        }



        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
				var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

				category.DateCreated = DateTime.UtcNow;
                category.DateUpdated = DateTime.UtcNow;
                category.UserCreated = userId;
                category.UserUpdated = userId;

                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

			var existing = await _context.Categories.FindAsync(id);

			if (existing == null) {
				return NotFound();
			}

			if (ModelState.IsValid)
            {
                try
                {
					var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

					existing.DateUpdated = DateTime.UtcNow;
					existing.UserUpdated = userId;
					existing.Name = category.Name;
                    _context.Update(existing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(existing.Id))
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
            return View(existing);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
