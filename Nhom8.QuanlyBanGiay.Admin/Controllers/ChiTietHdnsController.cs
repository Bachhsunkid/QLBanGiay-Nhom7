using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nhom8.QuanlyBanGiay.Admin.Models;

namespace Nhom8.QuanlyBanGiay.Admin.Controllers
{
    public class ChiTietHdnsController : Controller
    {
        private readonly QlbanGiayContext _context;

        public ChiTietHdnsController(QlbanGiayContext context)
        {
            _context = context;
        }

        // GET: ChiTietHdns
        public async Task<IActionResult> Index()
        {
            var qlbanGiayContext = _context.ChiTietHdns.Include(c => c.MaGiayNavigation).Include(c => c.MaHdnNavigation);
            return View(await qlbanGiayContext.ToListAsync());
        }

        // GET: ChiTietHdns/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ChiTietHdns == null)
            {
                return NotFound();
            }

            var chiTietHdn = await _context.ChiTietHdns
                .Include(c => c.MaGiayNavigation)
                .Include(c => c.MaHdnNavigation)
                .FirstOrDefaultAsync(m => m.MaHdn == id);
            if (chiTietHdn == null)
            {
                return NotFound();
            }

            return View(chiTietHdn);
        }

        // GET: ChiTietHdns/Create
        public IActionResult Create()
        {
            ViewData["MaGiay"] = new SelectList(_context.Giays, "MaGiay", "MaGiay");
            ViewData["MaHdn"] = new SelectList(_context.HoaDonNhaps, "MaHdn", "MaHdn");
            return View();
        }

        // POST: ChiTietHdns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHdn,MaGiay,SoLuong,KhuyenMai")] ChiTietHdn chiTietHdn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chiTietHdn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaGiay"] = new SelectList(_context.Giays, "MaGiay", "MaGiay", chiTietHdn.MaGiay);
            ViewData["MaHdn"] = new SelectList(_context.HoaDonNhaps, "MaHdn", "MaHdn", chiTietHdn.MaHdn);
            return View(chiTietHdn);
        }

        // GET: ChiTietHdns/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ChiTietHdns == null)
            {
                return NotFound();
            }

            var chiTietHdn = await _context.ChiTietHdns.FindAsync(id);
            if (chiTietHdn == null)
            {
                return NotFound();
            }
            ViewData["MaGiay"] = new SelectList(_context.Giays, "MaGiay", "MaGiay", chiTietHdn.MaGiay);
            ViewData["MaHdn"] = new SelectList(_context.HoaDonNhaps, "MaHdn", "MaHdn", chiTietHdn.MaHdn);
            return View(chiTietHdn);
        }

        // POST: ChiTietHdns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHdn,MaGiay,SoLuong,KhuyenMai")] ChiTietHdn chiTietHdn)
        {
            if (id != chiTietHdn.MaHdn)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chiTietHdn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChiTietHdnExists(chiTietHdn.MaHdn))
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
            ViewData["MaGiay"] = new SelectList(_context.Giays, "MaGiay", "MaGiay", chiTietHdn.MaGiay);
            ViewData["MaHdn"] = new SelectList(_context.HoaDonNhaps, "MaHdn", "MaHdn", chiTietHdn.MaHdn);
            return View(chiTietHdn);
        }

        // GET: ChiTietHdns/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ChiTietHdns == null)
            {
                return NotFound();
            }

            var chiTietHdn = await _context.ChiTietHdns
                .Include(c => c.MaGiayNavigation)
                .Include(c => c.MaHdnNavigation)
                .FirstOrDefaultAsync(m => m.MaHdn == id);
            if (chiTietHdn == null)
            {
                return NotFound();
            }

            return View(chiTietHdn);
        }

        // POST: ChiTietHdns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ChiTietHdns == null)
            {
                return Problem("Entity set 'QlbanGiayContext.ChiTietHdns'  is null.");
            }
            var chiTietHdn = await _context.ChiTietHdns.FindAsync(id);
            if (chiTietHdn != null)
            {
                _context.ChiTietHdns.Remove(chiTietHdn);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChiTietHdnExists(string id)
        {
          return _context.ChiTietHdns.Any(e => e.MaHdn == id);
        }
    }
}
