using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PlacesToVisitController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlacesToVisitController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: PlacesToVisit
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlaceToVisit.ToListAsync());
        }

        // GET: PlacesToVisit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placeToVisit = await _context.PlaceToVisit.SingleOrDefaultAsync(m => m.ItemId == id);
            if (placeToVisit == null)
            {
                return NotFound();
            }

            return View(placeToVisit);
        }

        // GET: PlacesToVisit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlacesToVisit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,City,DateToVisitBy,Description")] PlaceToVisit placeToVisit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(placeToVisit);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(placeToVisit);
        }

        // GET: PlacesToVisit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placeToVisit = await _context.PlaceToVisit.SingleOrDefaultAsync(m => m.ItemId == id);
            if (placeToVisit == null)
            {
                return NotFound();
            }
            return View(placeToVisit);
        }

        // POST: PlacesToVisit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,City,DateToVisitBy,Description")] PlaceToVisit placeToVisit)
        {
            if (id != placeToVisit.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(placeToVisit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaceToVisitExists(placeToVisit.ItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(placeToVisit);
        }

        // GET: PlacesToVisit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placeToVisit = await _context.PlaceToVisit.SingleOrDefaultAsync(m => m.ItemId == id);
            if (placeToVisit == null)
            {
                return NotFound();
            }

            return View(placeToVisit);
        }

        // POST: PlacesToVisit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var placeToVisit = await _context.PlaceToVisit.SingleOrDefaultAsync(m => m.ItemId == id);
            _context.PlaceToVisit.Remove(placeToVisit);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PlaceToVisitExists(int id)
        {
            return _context.PlaceToVisit.Any(e => e.ItemId == id);
        }
    }
}
