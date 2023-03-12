﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nhom8.QuanlyBanGiay.Admin.Models;

namespace Nhom8.QuanlyBanGiay.Admin.Controllers
{
    public class ChiTietHdbsController : Controller
    {
        private readonly QlbanGiayContext _context;

        public ChiTietHdbsController(QlbanGiayContext context)
        {
            _context = context;
        }

        // GET: ChiTietHdbs
        public async Task<IActionResult> Index()
        {
            var qlbanGiayContext = _context.ChiTietHdbs.Include(c => c.MaGiayNavigation).Include(c => c.MaHdbNavigation);
            return View(await qlbanGiayContext.ToListAsync());
        }

        // GET: ChiTietHdbs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ChiTietHdbs == null)
            {
                return NotFound();
            }

            var chiTietHdb = await _context.ChiTietHdbs
                .Include(c => c.MaGiayNavigation)
                .Include(c => c.MaHdbNavigation)
                .FirstOrDefaultAsync(m => m.MaHdb == id);
            if (chiTietHdb == null)
            {
                return NotFound();
            }

            return View(chiTietHdb);
        }

        // GET: ChiTietHdbs/Create
        public IActionResult Create()
        {
            ViewData["MaGiay"] = new SelectList(_context.Giays, "MaGiay", "MaGiay");
            ViewData["MaHdb"] = new SelectList(_context.HoaDonBans, "MaHdb", "MaHdb");
            return View();
        }

        // POST: ChiTietHdbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHdb,MaGiay,SoLuong,KhuyenMai")] ChiTietHdb chiTietHdb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chiTietHdb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaGiay"] = new SelectList(_context.Giays, "MaGiay", "MaGiay", chiTietHdb.MaGiay);
            ViewData["MaHdb"] = new SelectList(_context.HoaDonBans, "MaHdb", "MaHdb", chiTietHdb.MaHdb);
            return View(chiTietHdb);
        }

        // GET: ChiTietHdbs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ChiTietHdbs == null)
            {
                return NotFound();
            }

            var chiTietHdb = await _context.ChiTietHdbs.FindAsync(id);
            if (chiTietHdb == null)
            {
                return NotFound();
            }
            ViewData["MaGiay"] = new SelectList(_context.Giays, "MaGiay", "MaGiay", chiTietHdb.MaGiay);
            ViewData["MaHdb"] = new SelectList(_context.HoaDonBans, "MaHdb", "MaHdb", chiTietHdb.MaHdb);
            return View(chiTietHdb);
        }

        // POST: ChiTietHdbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHdb,MaGiay,SoLuong,KhuyenMai")] ChiTietHdb chiTietHdb)
        {
            if (id != chiTietHdb.MaHdb)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chiTietHdb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChiTietHdbExists(chiTietHdb.MaHdb))
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
            ViewData["MaGiay"] = new SelectList(_context.Giays, "MaGiay", "MaGiay", chiTietHdb.MaGiay);
            ViewData["MaHdb"] = new SelectList(_context.HoaDonBans, "MaHdb", "MaHdb", chiTietHdb.MaHdb);
            return View(chiTietHdb);
        }

        // GET: ChiTietHdbs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ChiTietHdbs == null)
            {
                return NotFound();
            }

            var chiTietHdb = await _context.ChiTietHdbs
                .Include(c => c.MaGiayNavigation)
                .Include(c => c.MaHdbNavigation)
                .FirstOrDefaultAsync(m => m.MaHdb == id);
            if (chiTietHdb == null)
            {
                return NotFound();
            }

            return View(chiTietHdb);
        }

        // POST: ChiTietHdbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ChiTietHdbs == null)
            {
                return Problem("Entity set 'QlbanGiayContext.ChiTietHdbs'  is null.");
            }
            var chiTietHdb = await _context.ChiTietHdbs.FindAsync(id);
            if (chiTietHdb != null)
            {
                _context.ChiTietHdbs.Remove(chiTietHdb);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChiTietHdbExists(string id)
        {
          return _context.ChiTietHdbs.Any(e => e.MaHdb == id);
        }
    }
}
