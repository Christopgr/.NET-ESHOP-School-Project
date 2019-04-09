using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.Include(p => p.Products).ToListAsync();  //kalei oti exei sto category gia na diale3oume meta ti akrivos
            return View(categories);

        }
        // GET: Products/Create
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description")] Category obj)
        { //                  view                     an vgalw kati den 8a to doume, oti vgike einai "sistemiko"=8ema security
            if (ModelState.IsValid)
            {
                obj.DateCreated = DateTime.UtcNow;
                obj.DateUpdated = DateTime.UtcNow;
                //products.CreatedBy
                //
                _context.Add(obj);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(obj);
        }
    }
}