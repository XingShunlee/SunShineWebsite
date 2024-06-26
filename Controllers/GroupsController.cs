﻿using ehaiker;
using ehaiker.Auth;
using ehaikerv202010.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ehaikerv202010.Controllers
{
    [AdminLoginStateRequiredAttribute]
    public class GroupsController : Controller
    {
        private readonly EhaikerContext _context;

        public GroupsController(EhaikerContext context)
        {
            _context = context;
        }

        // GET: Groups
        [AdminLoginStateRequiredAttribute]
        public async Task<IActionResult> Index()
        {
            return View(await _context.GroupTable.Where(r => r.Name != "superadmin").ToListAsync());
        }

        // GET: Groups/Details/5
        [AdminLoginStateRequiredAttribute]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.GroupTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        // GET: Groups/Create
        [AdminLoginStateRequiredAttribute]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminLoginStateRequiredAttribute]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,CreateTime,IsValidatedOK")] Group @group)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@group);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@group);
        }

        // GET: Groups/Edit/5
        [AdminLoginStateRequiredAttribute]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.GroupTable.FindAsync(id);
            if (@group == null)
            {
                return NotFound();
            }
            return View(@group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminLoginStateRequiredAttribute]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,CreateTime,IsValidatedOK")] Group @group)
        {
            if (id != @group.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@group);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupExists(@group.Id))
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
            return View(@group);
        }

        // GET: Groups/Delete/5
        [AdminLoginStateRequiredAttribute]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.GroupTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminLoginStateRequiredAttribute]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @group = await _context.GroupTable.FindAsync(id);
            _context.GroupTable.Remove(@group);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupExists(int id)
        {
            return _context.GroupTable.Any(e => e.Id == id);
        }
    }
}
