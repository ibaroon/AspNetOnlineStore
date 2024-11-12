using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
    public class CatigoriesController : Controller
    {
        SouqcomContext db;

        public CatigoriesController(SouqcomContext context)
        {
            db = context;
        }
        [Authorize]
        // GET: Catigories
        public async Task<IActionResult> Index()
        {
            return View(await db.Catigories.ToListAsync());
        }
        [Authorize]
        // GET: Catigories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catigory = await db.Catigories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catigory == null)
            {
                return NotFound();
            }

            return View(catigory);
        }
        [Authorize]
        // GET: Catigories/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: Catigories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Photo,Description")] Catigory catigory)
        {
            if (ModelState.IsValid)
            {
                db.Add(catigory);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catigory);
        }
        [Authorize]
        // GET: Catigories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catigory = await db.Catigories.FindAsync(id);
            if (catigory == null)
            {
                return NotFound();
            }
            return View(catigory);
        }
        [Authorize]
        // POST: Catigories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Photo,Description")] Catigory catigory)
        {
            if (id != catigory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(catigory);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatigoryExists(catigory.Id))
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
            return View(catigory);
        }
        [Authorize]
        // GET: Catigories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catigory = await db.Catigories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catigory == null)
            {
                return NotFound();
            }

            return View(catigory);
        }
        [Authorize]
        // POST: Catigories/Delete/5
        [HttpPost, ActionName("Delete")]
       
        public IActionResult DeleteConfirmed(int id)
        {
            var catigory = db.Catigories.Find(id);
            if (catigory != null)
            {
                db.Catigories.Remove(catigory);
            }

             db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        private bool CatigoryExists(int id)
        {
            return db.Catigories.Any(e => e.Id == id);
        }
    }
}
