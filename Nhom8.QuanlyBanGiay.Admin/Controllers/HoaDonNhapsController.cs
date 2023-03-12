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
    public class HoaDonNhapsController : Controller
    {
        private readonly QlbanGiayContext _context;

        public HoaDonNhapsController(QlbanGiayContext context)
        {
            _context = context;
        }

        // GET: HoaDonNhaps
        public async Task<IActionResult> Index()
        {
            var qlbanGiayContext = _context.HoaDonNhaps.Include(h => h.MaNccNavigation).Include(h => h.MaNvNavigation);
            return View(await qlbanGiayContext.ToListAsync());
        }

        // GET: HoaDonNhaps/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.HoaDonNhaps == null)
            {
                return NotFound();
            }

            var hoaDonNhap = await _context.HoaDonNhaps
                .Include(h => h.MaNccNavigation)
                .Include(h => h.MaNvNavigation)
                .FirstOrDefaultAsync(m => m.MaHdn == id);
            if (hoaDonNhap == null)
            {
                return NotFound();
            }

            return View(hoaDonNhap);
        }

        // GET: HoaDonNhaps/Create
        public IActionResult Create()
        {
            ViewData["MaNcc"] = new SelectList(_context.NhaCungCaps, "MaNcc", "MaNcc");
            ViewData["MaNv"] = new SelectList(_context.NhanViens, "MaNv", "MaNv");
            return View();
        }

        // POST: HoaDonNhaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHdn,MaNv,MaNcc,NgayNhap,TongTien")] HoaDonNhap hoaDonNhap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoaDonNhap);
                await _context.SaveChangesAsync();
                return RedirectToAction("HDN", "Home");
            }
            ViewData["MaNcc"] = new SelectList(_context.NhaCungCaps, "MaNcc", "MaNcc", hoaDonNhap.MaNcc);
            ViewData["MaNv"] = new SelectList(_context.NhanViens, "MaNv", "MaNv", hoaDonNhap.MaNv);
            return View(hoaDonNhap);
        }

        // GET: HoaDonNhaps/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.HoaDonNhaps == null)
            {
                return NotFound();
            }

            var hoaDonNhap = await _context.HoaDonNhaps.FindAsync(id);
            if (hoaDonNhap == null)
            {
                return NotFound();
            }
            ViewData["MaNcc"] = new SelectList(_context.NhaCungCaps, "MaNcc", "MaNcc", hoaDonNhap.MaNcc);
            ViewData["MaNv"] = new SelectList(_context.NhanViens, "MaNv", "MaNv", hoaDonNhap.MaNv);
            return View(hoaDonNhap);
        }

        // POST: HoaDonNhaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHdn,MaNv,MaNcc,NgayNhap,TongTien")] HoaDonNhap hoaDonNhap)
        {
            if (id != hoaDonNhap.MaHdn)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoaDonNhap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoaDonNhapExists(hoaDonNhap.MaHdn))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("HDN", "Home");
            }
            ViewData["MaNcc"] = new SelectList(_context.NhaCungCaps, "MaNcc", "MaNcc", hoaDonNhap.MaNcc);
            ViewData["MaNv"] = new SelectList(_context.NhanViens, "MaNv", "MaNv", hoaDonNhap.MaNv);
            return View(hoaDonNhap);
        }

        // GET: HoaDonNhaps/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.HoaDonNhaps == null)
            {
                return NotFound();
            }

            var hoaDonNhap = await _context.HoaDonNhaps
                .Include(h => h.MaNccNavigation)
                .Include(h => h.MaNvNavigation)
                .FirstOrDefaultAsync(m => m.MaHdn == id);
            if (hoaDonNhap == null)
            {
                return NotFound();
            }

            return View(hoaDonNhap);
        }

        // POST: HoaDonNhaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.HoaDonNhaps == null)
            {
                return Problem("Entity set 'QlbanGiayContext.HoaDonNhaps'  is null.");
            }
            var hoaDonNhap = await _context.HoaDonNhaps.FindAsync(id);
            if (hoaDonNhap != null)
            {
                _context.HoaDonNhaps.Remove(hoaDonNhap);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("HDN", "Home");
        }

        private bool HoaDonNhapExists(string id)
        {
          return _context.HoaDonNhaps.Any(e => e.MaHdn == id);
        }
    }
}
