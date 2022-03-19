namespace DigitGallery.WebApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using DigitGallery.Data;
    using DigitGallery.Models;

    public class DrawingsController : Controller
    {
        private readonly AppDbContext _context;

        public DrawingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Drawings
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Drawings.Include(d => d.Artist);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Drawings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drawing = await _context.Drawings
                .Include(d => d.Artist)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drawing == null)
            {
                return NotFound();
            }

            return View(drawing);
        }

        // GET: Drawings/Create
        public IActionResult Create()
        {
            ViewData["ArtistId"] = new SelectList(_context.Artists, "Id", "Name");
            return View();
        }

        [HttpGet]
        public IActionResult Search()
        {
            List<Drawing> drawings = new List<Drawing>();
            return View(drawings);
        }
        [HttpPost]
        public IActionResult Search(int minprice, int maxprice)
        {
            List<Drawing> drawings = _context.Drawings
                .Where(x => x.Price >= minprice && x.Price <= maxprice)
                .ToList();
            return View(drawings);
        }


        // POST: Drawings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Price,ImageUrl,Date,ArtistId")] Drawing drawing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drawing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Artists, "Id", "Name", drawing.ArtistId);
            return View(drawing);
        }

        // GET: Drawings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drawing = await _context.Drawings.FindAsync(id);
            if (drawing == null)
            {
                return NotFound();
            }
            ViewData["ArtistId"] = new SelectList(_context.Artists, "Id", "Name", drawing.ArtistId);
            return View(drawing);
        }

        // POST: Drawings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Price,ImageUrl,Date,ArtistId")] Drawing drawing)
        {
            if (id != drawing.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drawing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrawingExists(drawing.Id))
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
            ViewData["ArtistId"] = new SelectList(_context.Artists, "Id", "Name", drawing.ArtistId);
            return View(drawing);
        }

        // GET: Drawings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drawing = await _context.Drawings
                .Include(d => d.Artist)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drawing == null)
            {
                return NotFound();
            }

            return View(drawing);
        }

        // POST: Drawings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drawing = await _context.Drawings.FindAsync(id);
            _context.Drawings.Remove(drawing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrawingExists(int id)
        {
            return _context.Drawings.Any(e => e.Id == id);
        }
    }
}
