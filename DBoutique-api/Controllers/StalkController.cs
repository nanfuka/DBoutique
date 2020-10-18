using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Models;

namespace DBoutique.Controllers
{
    public class StalkController : Controller
    {
        private readonly StalkContext _context;

        public StalkController(StalkContext context)
        {
            _context = context;
        }

        // GET: Stalk
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stolk.ToListAsync());
        }

        // GET: Stalk/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stalk = await _context.Stolk
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stalk == null)
            {
                return NotFound();
            }

            return View(stalk);
        }

        // GET: Stalk/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stalk/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Description,Cost")] Stalk stalk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stalk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stalk);
        }

        // GET: Stalk/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stalk = await _context.Stolk.FindAsync(id);
            if (stalk == null)
            {
                return NotFound();
            }
            return View(stalk);
        }

        // POST: Stalk/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Description,Cost")] Stalk stalk)
        {
            if (id != stalk.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stalk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StalkExists(stalk.Id))
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
            return View(stalk);
        }

        // GET: Stalk/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stalk = await _context.Stolk
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stalk == null)
            {
                return NotFound();
            }

            return View(stalk);
        }

        // POST: Stalk/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stalk = await _context.Stolk.FindAsync(id);
            _context.Stolk.Remove(stalk);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StalkExists(int id)
        {
            return _context.Stolk.Any(e => e.Id == id);
        }
    }
}