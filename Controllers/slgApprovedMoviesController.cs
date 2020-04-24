using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using slgMultifunctional.Data;
using slgMultifunctional.Models;

namespace slgMultifunctional.Controllers
{
    public class slgApprovedMoviesController : Controller
    {
        private readonly slgMultifunctionalContext _context;

        public slgApprovedMoviesController(slgMultifunctionalContext context)
        {
            _context = context;
        }

        // GET: slgApprovedMovies
        public async Task<IActionResult> Index()
        {
            return View(await _context.slgApprovedMovies.ToListAsync());
        }

        // GET: slgApprovedMovies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slgApprovedMovies = await _context.slgApprovedMovies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slgApprovedMovies == null)
            {
                return NotFound();
            }

            return View(slgApprovedMovies);
        }

        // GET: slgApprovedMovies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: slgApprovedMovies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] slgApprovedMovies slgApprovedMovies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(slgApprovedMovies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(slgApprovedMovies);
        }

        // GET: slgApprovedMovies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slgApprovedMovies = await _context.slgApprovedMovies.FindAsync(id);
            if (slgApprovedMovies == null)
            {
                return NotFound();
            }
            return View(slgApprovedMovies);
        }

        // POST: slgApprovedMovies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] slgApprovedMovies slgApprovedMovies)
        {
            if (id != slgApprovedMovies.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slgApprovedMovies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!slgApprovedMoviesExists(slgApprovedMovies.Id))
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
            return View(slgApprovedMovies);
        }

        // GET: slgApprovedMovies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slgApprovedMovies = await _context.slgApprovedMovies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slgApprovedMovies == null)
            {
                return NotFound();
            }

            return View(slgApprovedMovies);
        }

        // POST: slgApprovedMovies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slgApprovedMovies = await _context.slgApprovedMovies.FindAsync(id);
            _context.slgApprovedMovies.Remove(slgApprovedMovies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool slgApprovedMoviesExists(int id)
        {
            return _context.slgApprovedMovies.Any(e => e.Id == id);
        }
    }
}
